using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.StudentDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Student_Service
{
    public interface IStudentService
    {
        ResponseDto Add(StudentRequestDto obj);
        List<StudentListDto> GetStudentList(int ParentID);

        StudentDetailDto GetStudentDetail(int StudentID);

       
    }
}
