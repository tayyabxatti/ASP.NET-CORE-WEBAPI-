using Clv.Models.ApiModels;
using Clv.Models.ApiModels.AuthenticateDto;
using Clv.Models.ApiModelsDto.AuthDto;
using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.ApiModelsDto.ParentDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.RoleDto;
using Clv.Models.ApiModelsDto.TeacherDtos;
using Clv.Models.Entities.UserEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Authenticate
{
    public interface IAuthenticateService
    {
        public UserTokenDto Authenticate(LoginDto _credentials);
        public List<GetRoleDto> GetRole();
        RegisterResp Register(RegisterDto registerDto);
        bool VerifyEmail(string key);
        public User GetUserByID(int UserID);
        public ForgotPasswordResDto ForgotPassword(ForgotPasswordRequestDto Request);
        ForgotPasswordResDto VerifyForgotPassword(VerifyPasswordReqDto Request);
        ResponseDto AddParent(AddParentDto obj);
        List<Get_Covid19_Assesment_Questions> GetCovidAssesmentQuestions();
        ResponseDto PostCovidAssesmentAnswers(List<Covid19_Assesment_Answers> obje);
        ResponseDto AddTeacher(TeacherRequestDto obj);
        List<TeacherListDto> GetTeacherList();

        ResponseDto ChangeTeacherStatus(TeacherStatusDto obj);
    }
}
