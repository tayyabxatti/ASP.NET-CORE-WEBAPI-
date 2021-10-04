using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Pod
{
    public interface IPodService
    {
        public List<PodGetDto> GetPodList();
        public Response Create(PodRequestDto model);
        public Response Update(PodEditDto model);
        public List<PodStudentsDto> GetPodStudent(int PodID);
        public List<AssignmentListDto> GetPodAssignment(int PodID);
        
    }
}
