using Clv.Core.Uow;
using Clv.Models.Entities.FileManager;
using Clv.Models.Entities.TeacherEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clv.Services.FileManager
{
    public class FileManagerService :IFileManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FileManagerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddProfileImage(ProfileImage profileImage)
        {
            var profileImageRespository = _unitOfWork.GetRepository<ProfileImage>();
            profileImageRespository.Add(profileImage);
            await _unitOfWork.CommitAsync();

        }

        public async Task AddTecherCv(TeacherCv teacherCv)
        {
            var teacherRespository = _unitOfWork.GetRepository<TeacherCv>();
            teacherRespository.Add(teacherCv);
            await _unitOfWork.CommitAsync();
        }
    }
}
