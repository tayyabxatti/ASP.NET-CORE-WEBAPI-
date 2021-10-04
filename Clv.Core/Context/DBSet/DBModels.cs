using Microsoft.EntityFrameworkCore;

using Clv.Models.Entities.UserEntity;
using Clv.Models.Entities.AssignmentEntity;
using Clv.Models.Entities.PodNStudent;
using Clv.Models.Entities.QuizEntity;
using Clv.Models.Entities;
using Clv.Models.Entities.AttendanceEntity;
using Clv.Models.Entities.NotesEntity;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.Entities.Covid_19_Assesment_Entity;
using Clv.Models.Entities.FileManager;
using Clv.Models.Entities.ParentEntity;
using Clv.Models.Entities.TeacherEntity;
using Clv.Models.Entities.GradeLevelEntity;
using Clv.Models.Entities.ParentEntity;

namespace Clv.Core.EFContext
{
    public partial class DatabaseContext
    {
        #region Tables Models
        public DbSet<User> db_Users { get; set; }
        public DbSet<Role> db_Roles { get; set; }
        public DbSet<Assignment> db_Assignment { get; set; }
        public DbSet<ProfileImage> db_ProfileImage{ get; set; }
        public DbSet<Parent> db_Parent { get; set; }
        public DbSet<User_Covid_Assesment> db_User_Covid_Assesment { get; set; }

        
        public DbSet<AssignmentSubmited> db_AssignmentSubmited { get; set; }
        public DbSet<AssignmentSubmitedFile> db_AssignmentSubmitedFile { get; set; }
        public DbSet<POD> db_Pod { get; set; }
        public DbSet<PodStudent> db_PodStudent { get; set; }
        public DbSet<Student> db_Student { get; set; }
        public DbSet<Quiz> db_Quiz { get; set; }
        public DbSet<QuizQuestions> db_QuizQuestions { get; set; }
        public DbSet<QuizQuestionOption> db_QuizQuestionOption { get; set; }
        public DbSet<QuizSubmited> db_QuizSubmited { get; set; }
        public DbSet<QuizSubmitedDetail> db_QuizSubmitedDetail { get; set; }
        public DbSet<Attendance> db_Attendance { get; set; }
        public DbSet<LearingStyle> db_LearingStyle { get; set; }
        public DbSet<Subject> db_Subject { get; set; }
        public DbSet<AssignmentFile> db_AssignmentFile { get; set; }
        public DbSet<Notes> db_Notes { get; set; }
        public DbSet<NotesFile> db_NotesFile { get; set; }
        public DbSet<DropDownCommon> db_DropDown { get; set; }
        public DbSet<Covid_Assesment> db_Covid_Assesment { get; set; }
        public DbSet<Teacher> db_Teacher { get; set; }
        public DbSet<TeacherCv> db_TeacherCv { get; set; }
        public DbSet<GradeLevel> db_GradeLevel { get; set; }
        public DbSet<SpecialNeed> db_SpecialNeed { get; set; }
        public DbSet<ParentPod> db_ParentPod { get; set; }
        
        #endregion Tables Models
    }
}
