using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.ApiModelsDto.ParentDto;
using Clv.Models.ApiModelsDto.ParentsDto;
using Clv.Models.ApiModelsDto.POD;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Models.ApiModelsDto.TeacherDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Parent_Services
{
    public interface IParentService
    {
        List<ParentDto> GetParentList();
        ParentDetailDto GetParentDetail(int UserID);
        TeacherDetailDto GetTeacherDetail(int UserID);
        List<CovidAnswereDetailDto> GetParentAnswereDetail(int UserID);
        List<StudentListDto> GetStudentList(int ParentID);
        List<PendingPodDto> GetParentPendingPods(int ParentID);

       PendingPodDetailDto GetParentPendingPodDetail(int ParentPodID);
       ResponseDto AddStudentToPod(PodStudentRquestDto obj);
    }
}
