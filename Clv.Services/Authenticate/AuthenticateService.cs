using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Clv.Core.Uow;
using Clv.Models.ApiModels;
using Clv.Models.ApiModels.AuthenticateDto;
using Clv.Models.ApiModelsDto.AuthDto;
using Clv.Models.ApiModelsDto.RoleDto;
using Clv.Models.Entities.UserEntity;
using Clv.Utilities.Hashing;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Clv.Utilities.Email.SendGrid;
using NLog.Fluent;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ParentDto;
using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.Entities.Covid_19_Assesment_Entity;
using Clv.Models.Entities.ParentEntity;
using Clv.Models.ApiModelsDto.TeacherDtos;
using Clv.Models.Entities.TeacherEntity;

namespace Clv.Services.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        List<Get_Covid19_Assesment_Questions> get_Covid19_Assesment_Questions;
        ResponseDto responseDto;
        public AuthenticateService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public UserTokenDto Authenticate(LoginDto _credentials)
        {
            _credentials.Password = SHA.GenerateSHA512String(_credentials.Password);
            var userRepository = _unitOfWork.GetRepository<User>();
            var parentRepository = _unitOfWork.GetRepository<Parent>();

            var user = userRepository.GetAll().Where(c => c.Email == _credentials.Email && c.PasswordHash == _credentials.Password).SingleOrDefault();
            if (user == null)
            {
                var errorMessage = new UserTokenDto
                {
                    ErrorMessage = "Invalid Email/Password"
                };
                return errorMessage;
            }
            var user_verified = userRepository.GetAll().Where(c => c.Email == _credentials.Email && c.PasswordHash == _credentials.Password && c.IsVerified == true).SingleOrDefault();
            if (user_verified == null)
            {
                var errorMessage = new UserTokenDto
                {
                    ErrorMessage = "Email not Verified"
                };
                return errorMessage;
            }

            int parentid = 0;
            var roleRepository = _unitOfWork.GetRepository<Role>();
            var userRole = roleRepository.GetAll().Where(c => c.RoleId == user.RoleId).SingleOrDefault();
            if (userRole == null)
                return null;
            if (userRole.RoleName == "Parent")
            {
                parentid = parentRepository.GetAll().Where(c => c.UserId == user.UserId).FirstOrDefault().ParentId;
            }
            //var UserId = new SqlParameter("@USER_ID", SqlDbType.Int) { Value = user.UserId };
            //var is_completed = _unitOfWork.SpRepository<ProfileIsCompleteDto>("USER_PROFILE_COMPLETED_CHECK @USER_ID", UserId);

            string token = JWTToken.GenerateToken(user.UserId.ToString(), user.IsProfileCompleted.ToString(), userRole.RoleName, user.Email, user.UserId.ToString(), parentid.ToString(), _appSettings.Secret);
            var userObj = new UserTokenDto
            {
                Token = "Bearer " + token,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Image = user.Avatar,
                LoginUserID = user.UserId,
                ParentID = parentid,
            };
            return userObj;
        }

        public List<GetRoleDto> GetRole()
        {
            var result = _unitOfWork.SpRepository<GetRoleDto>("GetUserRoles");
            return result;
        }

        public User GetUserByID(int UserID)
        {
            try
            {
                var userRepository = _unitOfWork.GetRepository<User>();
                var userDetail = userRepository.GetAll().SingleOrDefault(x => x.UserId == UserID);
                return userDetail;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public RegisterResp Register(RegisterDto registerDto)
        {

            var userRepository = _unitOfWork.GetRepository<User>();
            var exists = userRepository.GetAll().SingleOrDefault(x => x.Email == registerDto.Email);
            var user_role = 0;
            if (exists == null)
            {

                var roleRepository = _unitOfWork.GetRepository<Role>();
                var role_exists = roleRepository.GetAll().SingleOrDefault(x => x.RoleName == registerDto.UserType);
                if (role_exists == null)
                {
                    Role role = new Role();
                    role.RoleName = registerDto.UserType;
                    roleRepository.Add(role);
                    _unitOfWork.Commit();
                    user_role = role.RoleId;
                }
                else
                {
                    var role_id = roleRepository.GetAll().SingleOrDefault(x => x.RoleName == registerDto.UserType);
                    user_role = role_id.RoleId;
                }
                User user = new User
                {
                    PasswordHash = SHA.GenerateSHA512String(registerDto.Password),
                    Email = registerDto.Email,
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    RoleId = user_role,
                    IsVerified = false
                };
                userRepository.Add(user);
                _unitOfWork.Commit();
                var userDetail = userRepository.GetAll().SingleOrDefault(x => x.Email == registerDto.Email);
                SendGridEmail.SendVerificationEmail(user.Email, user.Username, user.FirstName, user.LastName, userDetail.UserId.ToString());
                //ELO ELO ELLLLLOOO
                //LoginDto loginDto = new LoginDto();
                //loginDto.Email = registerDto.Email;
                //loginDto.Password = registerDto.Password;
                //UserTokenDto userToken=Authenticate(loginDto);
                RegisterResp register = new RegisterResp();
                register.Message = "Success";
                register.Status = "OK";
                return register;
            }
            else
            {
                RegisterResp registerMessage = new RegisterResp();
                registerMessage.Message = "User Already Exists";
                registerMessage.Status = "BAD";
                return registerMessage;
            }
        }

        public bool VerifyEmail(string key)
        {
            try
            {
                var userRepository = _unitOfWork.GetRepository<User>();
                var userDetail = userRepository.GetAll().Where(c => c.UserId == int.Parse(key)).SingleOrDefault();
                if (userDetail != null)
                {
                    userDetail.IsVerified = true;
                    userRepository.Update(userDetail);
                    _unitOfWork.Commit();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public bool UpdateUserProfile(UpdateUserRequestDto ModelUpdateUser)
        //{
        //    try
        //    {
        //        var userRepository = _unitOfWork.GetRepository<User>();
        //        var exists = userRepository.GetAll().SingleOrDefault(x => x.UserId == ModelUpdateUser.UserID);
        //        if (exists != null)
        //        {
        //            exists.FirstName = ModelUpdateUser.FirstName;
        //            exists.LastName = ModelUpdateUser.LastName;
        //            exists.Username = ModelUpdateUser.Username;
        //            exists.Email = ModelUpdateUser.Email;
        //            exists.Country = ModelUpdateUser.Country;
        //            exists.City = ModelUpdateUser.City;
        //            exists.State = ModelUpdateUser.State;
        //            exists.Street = ModelUpdateUser.Street;
        //            exists.DateOfBirth = ModelUpdateUser.DateOfBirth;
        //            exists.ZipCode = ModelUpdateUser.ZipCode;
        //            exists.Willing_To_Travel = ModelUpdateUser.Willing_To_Travel;
        //            exists.Pod_Primary_Lang = ModelUpdateUser.Pod_Primary_Lang;
        //            exists.Pod_Sec_Lang = ModelUpdateUser.Pod_Sec_Lang;
        //            exists.Certification_Status = ModelUpdateUser.Certification_Status;
        //            exists.Preffered_Grade_Level = ModelUpdateUser.Preffered_Grade_Level;
        //            exists.Special_Teaching_Skills = ModelUpdateUser.Special_Teaching_Skills;
        //            exists.Avatar = ModelUpdateUser.Avatar;
        //            //exists.TeacherCvId = ModelUpdateUser.TeacherCvId;
        //            exists.UploadCV = ModelUpdateUser.UploadCV;
        //            exists.ParentStatus = ModelUpdateUser.ParentStatus;
        //            exists.CaregiverStatus = ModelUpdateUser.CaregiverStatus;
        //            exists.PodLearningEnvironment = ModelUpdateUser.PodLearningEnvironment;

        //            userRepository.Update(exists);
        //            _unitOfWork.Commit();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string a = ex.Message;
        //        return false;
        //    }
        //}
        public ForgotPasswordResDto ForgotPassword(ForgotPasswordRequestDto Request)
        {
            try
            {
                ForgotPasswordResDto result = new ForgotPasswordResDto();
                var userRepository = _unitOfWork.GetRepository<User>();
                var exists = userRepository.GetAll().SingleOrDefault(x => x.Email == Request.Email);
                if (exists == null)
                {
                    result.Success = false;
                    result.Message = "Email does not exist in our system!";
                    return result;
                }
                User user = new User
                {
                    Email = exists.Email,
                };
                SendGridEmail.ForgotPassword(user.Email);
                result.Success = true;
                result.Message = "Reset Password mail sent to you email.";
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ForgotPasswordResDto VerifyForgotPassword(VerifyPasswordReqDto Request)
        {
            try
            {
                ForgotPasswordResDto result = new ForgotPasswordResDto();
                var userRepository = _unitOfWork.GetRepository<User>();
                var exists = userRepository.GetAll().SingleOrDefault(x => x.Email == Request.Email);
                if (exists != null)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(exists.PasswordHash);

                    if (SHA.GetStringFromHash(bytes) == Request.Password)
                    {
                        result.Success = true;
                        result.Message = "Please use new password.";
                        return result;
                    }
                    else
                    {
                        exists.IsVerified = true;
                        exists.PasswordHash = SHA.GenerateSHA512String(Request.Password); //NewPassword
                        userRepository.Update(exists);
                        _unitOfWork.Commit();

                        result.Success = true;
                        result.Message = "Password updated successfully.";
                        return result;
                    }
                }
                else
                {
                    result.Message = "User does not exist, Invalid link";
                    result.Success = false;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseDto AddParent(AddParentDto obj)
        {
            var parentRepository = _unitOfWork.GetRepository<Parent>();
            var userRepo = _unitOfWork.GetRepository<User>();
            try
            {
               Parent parent = new Parent()
                {
                    Country = obj.Country,
                    City = obj.City,
                    State = obj.State,
                    Street = obj.Street,
                    DOB = obj.DOB,
                    ZipCode = obj.ZipCode,
                    //Pod_Primary_Language = obj.Pod_Primary_Language,
                    //Pod_Secondary_Language = obj.Pod_Secondary_Language,
                    //Parent_Status = obj.Parent_Status,
                    //Caregiver_Status = obj.Caregiver_Status,
                    //Pod_Learning_Environment = obj.Pod_Learning_Environment,
                    Profile_Image = obj.Profile_Image,
                    UserId = obj.UserId,
                };
                Parent parent1 = parentRepository.Save(parent);
                _unitOfWork.Commit();

                if (parent1 != null)
                {
                    User user = userRepo.GetAll().Where(x => x.UserId == parent1.UserId).FirstOrDefault();
                    user.IsProfileCompleted = true;
                    userRepo.Update(user);
                    _unitOfWork.Commit();

                    if (user.UserId > 0 && user.IsProfileCompleted == true)
                    {
                        ParentPod parentPod = new ParentPod()
                        {
                            Pod_Primary_Language = obj.Pod_Primary_Language,
                            Pod_Secondary_Language = obj.Pod_Secondary_Language,
                            Parent_Status = obj.Parent_Status,
                            Caregiver_Status = obj.Caregiver_Status,
                            Pod_Learning_Environment = obj.Pod_Learning_Environment,
                            Status = "Pending",
                            Parent_ID = parent.ParentId,
                        };
                        //parentRepository.Add(parentPod);
                        //parentPodRepository.Save(parentPod);
                        _unitOfWork.Commit();
                    }
                }
                return responseDto = new ResponseDto()
                {
                    Success = true,
                    Message = "Parent record hasbeen created successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Get_Covid19_Assesment_Questions> GetCovidAssesmentQuestions()
        {
            try
            {
                var userRepository = _unitOfWork.GetRepository<Covid_Assesment>();
                get_Covid19_Assesment_Questions = new List<Get_Covid19_Assesment_Questions>();
                return get_Covid19_Assesment_Questions = userRepository.GetAll().Select(
                 r => new Get_Covid19_Assesment_Questions()
                 {
                     Covid_Question_ID = r.Covid_Question_ID,
                     Question_Description = r.Question_Description,

                 }).ToList();
            }
            catch (Exception ex) 

            {
                throw ex;
            }
        }

        public ResponseDto PostCovidAssesmentAnswers(List<Covid19_Assesment_Answers> obje)
        {
            var covidRepository = _unitOfWork.GetRepository<User_Covid_Assesment>();
            List<User_Covid_Assesment> covid_Assesments = new List<User_Covid_Assesment>();
            try
            {
                foreach (var question in obje)
                {
                    User_Covid_Assesment user_Covid_Assesment = new User_Covid_Assesment()
                    {
                        UserId = question.User_id,
                        Covid_Question_Id = question.QuestionId,
                        Is_Answer_True = question.Check_yes == "yes" ? true : false,
                    };
                    covidRepository.Add(user_Covid_Assesment);
                    _unitOfWork.Commit();

                    //var userRepository = _unitOfWork.GetRepository<User>();
                    //var user = userRepository.GetAll().Where(x => x.UserId == question.User_id).SingleOrDefault();
                    //user.IsProfileCompleted = true;
                    //userRepository.Update(user);
                    //_unitOfWork.Commit();
                }
                
                return responseDto = new ResponseDto()
                {
                    Success = true,
                    Message = "Assessment answere hasbeen save successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseDto AddTeacher(TeacherRequestDto obj)
        {
            try
            {
                var teacherRepository = _unitOfWork.GetRepository<Teacher>();
                var cvRepository = _unitOfWork.GetRepository<TeacherCv>();
                var userRepository = _unitOfWork.GetRepository<User>();

                Teacher teacher = new Teacher()
                {
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Email = obj.Email,
                    Country = obj.Email,
                    City = obj.City,
                    State = obj.State,
                    Street = obj.Street,
                    DOB = obj.DOB,
                    ZipCode = obj.Email,
                    WillingTotravel = obj.Email,
                    Pod_Secondary_Language = obj.Email,
                    Certification_Status = obj.Email,
                    Preferred_Grade_Level = obj.Email,
                    Teaching_skills = obj.Email,
                    Teachercv_ID = obj.TeacherCvId,
                    Profile_Image = obj.Profile_Image,
                    UserId = obj.UserId,
                };

                Teacher teacherResponse = teacherRepository.Save(teacher);
                if (teacherResponse != null)
                {
                    User user = userRepository.GetAll().Where(x => x.UserId == teacher.UserId).FirstOrDefault();
                    user.IsProfileCompleted = true;
                    userRepository.Update(user);
                }
                _unitOfWork.Commit();
                return responseDto = new ResponseDto()
                {
                    Success = true,
                    Message = "Parent record hasbeen created successfully"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TeacherListDto> GetTeacherList()
        {
            List<TeacherListDto> teacherListDtos = new List<TeacherListDto>();

            try
            {
                teacherListDtos = _unitOfWork.SpRepository<TeacherListDto>("[dbo].[Sp_GetTeachertList]").ToList();
                return teacherListDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseDto ChangeTeacherStatus(TeacherStatusDto obj)
        {
            try
            {
                var teacherRepository = _unitOfWork.GetRepository<Teacher>();
                Teacher teacher = teacherRepository.GetAll().Where(x => x.TeacherID == obj.TeacherId).FirstOrDefault();
                teacher.Status = obj.Status;
                teacherRepository.Update(teacher);
                return responseDto = new ResponseDto()
                {
                    Success = true,
                    Message = "Teacher Status Hasbeen updated successfully",
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
