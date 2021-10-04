using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Assignment
{
    public interface IAssignmentService
    {
        public ResponseDto Create(AssignmentDto model);
        public ResponseDto SubmitAssignment(AssignmentSubmitDto  assignmentSubmitDto);
        public List<AssignmentListDto> GetList(int Pod_ID);
        public AssignmentDetailDto GetDetailByID(int AssignmentID);
        public List<AssignmentSubmitedDto> GetStudentAssignmentDetail(int AssignmentID);
    }
}
