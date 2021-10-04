using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Models.Entities.PodNStudent;
using Clv.Models.Entities.UserEntity;
using Clv.Utilities.Hashing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Clv.Services.Student_Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        ResponseDto responseDtos;
        StudentDetailDto StudentDetailDto;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            StudentDetailDto = new StudentDetailDto();
        }
        public ResponseDto Add(StudentRequestDto request)
        {
            try
            {
                var userRepo = _unitOfWork.GetRepository<User>();
                int roleId = 0;

                var roleRepository = _unitOfWork.GetRepository<Role>();
                var role_exists = roleRepository.GetAll().SingleOrDefault(x => x.RoleName == "Student");
                if (role_exists == null)
                {
                    Role role = new Role();
                    role.RoleName = "Student";
                    roleRepository.Add(role);
                    _unitOfWork.Commit();
                    roleId = role.RoleId;
                }
                else
                {
                    var role_id = roleRepository.GetAll().SingleOrDefault(x => x.RoleName == "Student");
                    roleId = role_id.RoleId;
                }
                User user = new User
                {
                    PasswordHash = SHA.GenerateSHA512String(request.Password),
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    RoleId = roleId,
                    IsVerified = true,
                    IsProfileCompleted = true
                };
                User response = userRepo.Save(user);
                _unitOfWork.Commit();
                var stdRepo = _unitOfWork.GetRepository<Student>();
                Student student = new Student()
                {
                    SpecialNeed_ID = Int32.Parse( request.SpecialNeed_ID),
                    LearningStyle_ID = Int32.Parse(request.LearningStyle_ID),
                    Parent_ID =request.Parent_ID,
                    Subject_ID = Int32.Parse(request.Subject_ID),
                    GradeLevel_ID = Int32.Parse(request.GradeLevel_ID),
                    ImgeFileID = request.ImgeFile_ID,
                    CreatedDate = DateTime.Now,
                    User_Id = response.UserId,
                };
                stdRepo.Add(student);
                _unitOfWork.Commit();
                return responseDtos = new ResponseDto()
                {
                    Success = true,
                    Message = "Record hasbeen created successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentDetailDto GetStudentDetail(int StudentID)
        {
            try
            {
                 var p = new SqlParameter("@StudentID", SqlDbType.Int).Value = (Convert.ToString(StudentID) ?? (object)DBNull.Value);
                 StudentDetailDto = _unitOfWork.SpRepository<StudentDetailDto>("[dbo].[sp_GetStudentDetail] {0}", p).FirstOrDefault();
                return StudentDetailDto;
            }
            catch (Exception ex)
            {
                throw ex;
           }
        }

        public List<StudentListDto> GetStudentList(int ParentID)
        {
            throw new NotImplementedException();
        }
    }
}
