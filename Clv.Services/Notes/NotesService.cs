using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.NotesDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.Entities.NotesEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Clv.Services.Notes
{
    public class NotesService : INotesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public List<NoteDto> Notes;
        Response respons;
        public NotesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response Create(NotesRequestDto notesRequest)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Models.Entities.NotesEntity.Notes>();
                Models.Entities.NotesEntity.Notes notes = new Models.Entities.NotesEntity.Notes()
                {
                    Description = notesRequest.Description,
                    Pod_ID = notesRequest.Pod_ID,
                    CreateDate = DateTime.Now,
                };
                repository.Add(notes);
                _unitOfWork.Commit();
                var repoNofile = _unitOfWork.GetRepository<NotesFile>();
                List<NotesFile> filesList = new List<NotesFile>();
                foreach (var files in notesRequest.notesFileRequestDtos)
                {
                    NotesFile file = new NotesFile()
                    {
                        Data = files.Data,
                        FileName = files.FileName,
                        Extension = files.Extension,
                        ContentType = files.ContentType,
                        Notes_ID = notes.NotesID
                    };
                    filesList.Add(file);
                }
                repoNofile.AddRanges(filesList);
                _unitOfWork.Commit();

                return respons = new Response()
                {
                    StatusCode = "Ok",
                    Success = true,
                    Message = "Nots has been created successfully"
                };
            }
            catch (Exception)
            {
                return respons = new Response()
                {
                    Success = false,
                    StatusCode = "Error",
                    Message = "Some thing wrong please try again later"
                };
            }
        }

        public NoteDto GetNotesByID(int NoteID)
        {
            try
            {
                NoteDto Notes = new NoteDto();
                var noteId = new SqlParameter("@NotesID", SqlDbType.Int).Value = (Convert.ToString(NoteID) ?? (object)DBNull.Value);
                Notes = _unitOfWork.SpRepository<NoteDto>("[dbo].[sp_GetNotesDetailByID] @NotesID", noteId).FirstOrDefault();
                return Notes;
            }
            catch (Exception)
            {
                return new NoteDto();
            }
        }

        public Response Delete(int NotesId)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Models.Entities.NotesEntity.Notes>();
                Models.Entities.NotesEntity.Notes notes = repository.GetAll().Where(n => n.NotesID == NotesId).FirstOrDefault();
                var notesFileRepo = _unitOfWork.GetRepository<NotesFile>();
                var notesFiles = notesFileRepo.GetAll().Where(n => n.Notes_ID == NotesId).ToList();
                if (notesFiles.Count > 0)
                {
                    foreach (var item in notesFiles)
                    {
                        notesFileRepo.HardDelete(item);
                        _unitOfWork.Commit();
                    }
                }
                repository.HardDelete(notes);
                _unitOfWork.Commit();
                return respons = new Response()
                {
                    StatusCode = "Ok",
                    Message = "Notes has been deleted successfully"
                };
            }
            catch (Exception)
            {
                return respons = new Response()
                {
                    StatusCode = "Ok",
                    Message = "Some thing went wrong plase try again later"
                };
            }
        }

        public List<NoteDto> GetNotesList(int PodID)
        {
            try
            {
                Notes = new List<NoteDto>();
                var noteId = new SqlParameter("@Pod_ID", SqlDbType.Int).Value = (Convert.ToString(PodID) ?? (object)DBNull.Value);
                Notes = _unitOfWork.SpRepository<NoteDto>("[dbo].[sp_GetPodNotes] {0}", PodID).ToList();
                return Notes;
            }
            catch (Exception)
            {
                return Notes = new List<NoteDto>();
            }
        }

        public NotesFileRequestDto GetFile(int FileID)
        {
            var repository = _unitOfWork.GetRepository<Models.Entities.NotesEntity.NotesFile>();
            var notes = repository.GetAll().Where(n => n.NotesFileId == FileID).Select(r => new NotesFileRequestDto()
            {
                Data = r.Data,
                FileName = r.FileName,
                Extension = r.Extension,
                ContentType = r.ContentType,
            }).FirstOrDefault();

            return notes;

        }
    }
}
