using Clv.Models.Entities.FileManager;
using Clv.Models.Entities.TeacherEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clv.Services.FileManager
{
   public interface IFileManagerService
    {
        public Task AddProfileImage(ProfileImage profileImage);
        public Task AddTecherCv(TeacherCv teacherCv);

    }
}
