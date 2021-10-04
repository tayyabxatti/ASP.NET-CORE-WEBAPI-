using Microsoft.EntityFrameworkCore;
using Clv.Models.ApiModels.AuthenticateDto;
using Clv.Models.ApiModelsDto.QuizDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.NotesDto;
using Clv.Models.ApiModelsDto.ParentsDto;
using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.ApiModelsDto.TeacherDtos;
using Clv.Models.ApiModelsDto.GradeLevelDto;
using Clv.Models.ApiModelsDto.SpecialNeedDto;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Models.ApiModelsDto.POD;

namespace Clv.Core.EFContext
{
    public partial class DatabaseContext
    {
        #region Sp Models
        public DbSet<AssociatedUserIDDto> AssociatedUserIDs { get; set; }
        public DbSet<PodGetDto> ds_PdoGetDto { get; set; }
        public DbSet<PodStudentsDto> ds_AllPodStudentByID { get; set; }
        public DbSet<QuizListDto> ds_AQuizListByPodID { get; set; }
        public DbSet<QuizList> ds_QuizList { get; set; }
        public DbSet<QuizResultDto> ds_QuizResultList { get; set; }
        public DbSet<AssignmentListDto> ds_AssignmentList { get; set; }
        public DbSet<AssignmentDetailDto> ds_AssignmentDetailDto { get; set; }
        public DbSet<PodGetDto> dsPdoGetDto { get; set; }
        public DbSet<PodStudentsDto> dsAllPodStudentByID { get; set; }
        public DbSet<QuizListDto> dsAQuizListByPodID { get; set; }
        public DbSet<QuizList> dsQuizList { get; set; }
        public DbSet<AssignmentListDto> dsAssignmentList { get; set; }
        public DbSet<NoteDto> dsNotes { get; set; }
        public DbSet<AssignmentSubmitedDto> dsStudentAssignment { get; set; }
        public DbSet<ParentDto> dsparentDtos { get; set; }
        public DbSet<ParentDetailDto> dsparentDetail { get; set; }
        public DbSet<CovidAnswereDetailDto> dsCovidAnswereDetailDto { get; set; }
        public DbSet<TeacherDetailDto> DsteacherDetailDtos { get; set; }
        public DbSet<TeacherListDto> DsteacherListDtos { get; set; }
        public DbSet<GradeLevelListDto> DsGradeLevelListDto { get; set; }
        public DbSet<StudentDetailDto> DsStudentDetailDto { get; set; }
        public DbSet<SpecialNeedListDto> DsSpecialNeedListDto { get; set; }
        public DbSet<StudentListDto > DsStudentListDto  { get; set; }
        public DbSet<PendingPodDto> DsPendingPodDto { get; set; }
        public DbSet<PendingPodDetailDto> DsPendingPodDetailDto { get; set; }

        #endregion Sp Models
    }
}
