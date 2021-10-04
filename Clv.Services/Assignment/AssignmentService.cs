using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.Entities.AssignmentEntity;
using Clv.Utilities.Hashing;
using Microsoft.Extensions.Options;

namespace Clv.Services.Assignment
{
    public class AssignmentService : IAssignmentService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        ResponseDto responseDtos;
        List<AssignmentListDto> assignmentListDtos;
        List<AssignmentSubmitedDto> assignmentSubmitedDtos;
        AssignmentDetailDto assignmentDetailDtos;
        public AssignmentService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            assignmentListDtos = new List<AssignmentListDto>();
            assignmentDetailDtos = new AssignmentDetailDto();
            assignmentSubmitedDtos = new List<AssignmentSubmitedDto>();

        }

        public ResponseDto Create(AssignmentDto assignmentDto)
        {
            try
            {
                var assignRepo = _unitOfWork.GetRepository<Models.Entities.AssignmentEntity.Assignment>();
                Models.Entities.AssignmentEntity.Assignment assignment = new Models.Entities.AssignmentEntity.Assignment();
                assignment.Title = assignmentDto.Title;
                assignment.Description = assignmentDto.Description;
                assignment.AssignedOn = assignmentDto.AssignedOn;
                assignment.LastDate = assignmentDto.LastDate;
                assignRepo.Save(assignment);
                _unitOfWork.Commit();
                var assignFileRepo = _unitOfWork.GetRepository<AssignmentFile>();
                List<AssignmentFile> assignmentFile = new List<AssignmentFile>();
                foreach (var item in assignmentDto.Files)
                {
                    assignmentFile.Add(new AssignmentFile()
                    {
                        Assignment_ID = assignment.AssignmentID,
                        FileExt = item.Extension,
                        ContectType = item.ContentType,
                        Data = item.File
                    });
                }
                assignFileRepo.AddRanges(assignmentFile);
                _unitOfWork.Commit();
                return responseDtos = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has beeen created Successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async void SendEmailThread(int ID)
        {
            Task task = new Task(() => SendAssignmentNotification(ID));
            task.Start();
            await task;
        }
        public void SendAssignmentNotification(int AssignmentID)
        {

            #region EmailGenerate OLD
            //var emailRepo = _unitOfWork.GetRepository<Models.Entities.AssignmentEntity.Assignment>();  //Funcationality
            //List<AssignmentEmailDto> assignmentDtos = new List<AssignmentEmailDto>();

            //var p = new SqlParameter("@AssignmentID", SqlDbType.Int).Value = (Convert.ToString(AssignmentID) ?? (object)DBNull.Value);
            //assignmentDtos = _unitOfWork.SpRepository<AssignmentEmailDto>("[dbo].[sp_GeDetailForAssignmentEmail] {0}", p).ToList();

            //ArrayList list_emails = new ArrayList();  // In this arraylist you can set the group of mails that you want to communicate  

            //List<MailMessage> mailMessages = new List<MailMessage>();
            //var mailMessage = new MailMessage { Subject = "Invoice from DFP Productions" };
            //var htmlBody = "";
            //foreach (var item in assignmentDtos)
            //{
            //    MailMessage mailMessage1 = new MailMessage();
            //    mailMessage1.To.Add(item.StudentEmail);
            //    mailMessage1.To.Add(item.ParentEmail);
            //    mailMessage1.Subject = "Assignment for Subject: " + item.SubjectName;
            //    mailMessage1.Body = htmlBody;
            //    mailMessage1.IsBodyHtml = true;

            //    htmlBody = "Dear " + item.FatherName + ",";
            //    htmlBody += "<br> </br>";
            //    htmlBody += "Assignment is Scadual For :" + item.AssignedOn + " EndDate: " + item.LastDate;
            //    mailMessages.Add(mailMessage1);
            //    SendGridEmail.SendEmail(item.ParentEmail, htmlBody);
            //    SendGridEmail.SendEmail(item.StudentEmail, htmlBody);
            //}
            #endregion


            #region EmailGenerate NEW
            var emailRepo = _unitOfWork.GetRepository<Models.Entities.AssignmentEntity.Assignment>();  //Funcationality
            List<AssignmentEmailDto> assignmentDtos = new List<AssignmentEmailDto>();

            var p = new SqlParameter("@AssignmentID", SqlDbType.Int).Value = (Convert.ToString(AssignmentID) ?? (object)DBNull.Value);
            assignmentDtos = _unitOfWork.SpRepository<AssignmentEmailDto>("[dbo].[sp_GeDetailForAssignmentEmail] {0}", p).ToList();

            // ArrayList list_emails = new ArrayList();  // In this arraylist you can set the group of mails that you want to communicate  
            //List<MailMessage> mailMessages = new List<MailMessage>();  //MailList

            MailMessage mailMessage = new MailMessage(); //Object   //{ Subject = "Invoice from DFP Productions" };
            var htmlBody = "";
            foreach (var item in assignmentDtos)
            {
                mailMessage.To.Add(item.StudentEmail);
                if (item.ParentEmail.Length > 0 || item.ParentEmail.ToString() != "")
                    mailMessage.CC.Add(item.ParentEmail);
                mailMessage.Subject = "Assignment for Subject: " + item.SubjectName;

                htmlBody = "Dear " + item.FatherName + ",";
                htmlBody += "<br> </br>";
                htmlBody += "Assignment is Scadual For :" + item.AssignedOn + " EndDate: " + item.LastDate;
                mailMessage.Body = htmlBody;
                mailMessage.IsBodyHtml = true;

                string MailFrom = "samarbudhni@gmail.com";  //From
                mailMessage.From = new MailAddress(MailFrom);
                string MailPassword = null;//"Pasword Ws Removed";

                SmtpClient sC = new SmtpClient("smtp.gmail.com", 587);
                sC.EnableSsl = true;
                sC.UseDefaultCredentials = false;

                sC.Credentials = new NetworkCredential(MailFrom, MailPassword);//";
                sC.Host = "smtp.gmail.com";
                sC.Port = 587;
                sC.DeliveryMethod = SmtpDeliveryMethod.Network;
                sC.Send(mailMessage);
            }
            #endregion
        }

        #region OLD
        //public Response SubmitAssignment(AssignmentSubmitDto assignmentSubmitDto)
        //{
        //    try
        //    {
        //        var repoSubmit = _unitOfWork.GetRepository<AssignmentSubmited>();
        //        AssignmentSubmited assignmentSubmited = new AssignmentSubmited()
        //        {
        //            Assignment_ID = assignmentSubmitDto.Assignment_ID,
        //            Student_ID = assignmentSubmitDto.Student_ID,
        //            TotalMarks = assignmentSubmitDto.TotalMarks,
        //            SubmitedDate = DateTime.Now,
        //            IsActive = true
        //        };
        //        repoSubmit.Save(assignmentSubmited);
        //        _unitOfWork.Commit();

        //        var repoSubmitFile = _unitOfWork.GetRepository<AssignmentSubmitedFile>();
        //        List<AssignmentSubmitedFile> submitedFiles = new List<AssignmentSubmitedFile>();
        //        foreach (var item in assignmentSubmitDto.Files)
        //        {
        //            submitedFiles.Add(new AssignmentSubmitedFile()
        //            {
        //                AssignmentSubmited_ID = assignmentSubmited.AssignmentSubmitedID,
        //                Extension = item.Extension,
        //                ContentType = item.ContentType,
        //                Data = item.File
        //            });
        //        }
        //        repoSubmitFile.AddRanges(submitedFiles);
        //        _unitOfWork.Commit();
        //        return responseDtos = new Response()
        //        {
        //            StatusCode = "200",
        //            Message = "Assignment has been Submited Successfully"
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        return responseDtos = new Response()
        //        {
        //            StatusCode = "500",
        //            Message = "Some thing went wrong please try again later"
        //        };
        //    }
        //}

        #endregion
        public ResponseDto SubmitAssignment(AssignmentSubmitDto assignmentSubmitDto)
        {
            try
            {
                var repoSubmit = _unitOfWork.GetRepository<AssignmentSubmited>();
                #region FirstTime
                if (assignmentSubmitDto.SubmitStatus == "Submit")
                {
                    AssignmentSubmited assignmentSubmited = new AssignmentSubmited()
                    {
                        Assignment_ID = assignmentSubmitDto.Assignment_ID,
                        Student_ID = assignmentSubmitDto.Student_ID,
                        TotalMarks = assignmentSubmitDto.TotalMarks,
                        SubmitedDate = DateTime.Now,
                        IsActive = true
                    };
                     repoSubmit.Save(assignmentSubmited);
                    _unitOfWork.Commit();

                    var repoSubmitFile = _unitOfWork.GetRepository<AssignmentSubmitedFile>();
                    List<AssignmentSubmitedFile> submitedFiles = new List<AssignmentSubmitedFile>();
                    foreach (var item in assignmentSubmitDto.Files)
                    {
                        submitedFiles.Add(new AssignmentSubmitedFile()
                        {
                            AssignmentSubmited_ID = assignmentSubmited.AssignmentSubmitedID,
                            Extension = item.Extension,
                            ContentType = item.ContentType,
                            Data = item.File
                        });
                    }
                    repoSubmitFile.AddRanges(submitedFiles);
                }
                if (assignmentSubmitDto.SubmitStatus == "ReSubmit")
                {
                    var repoSubmitFile = _unitOfWork.GetRepository<AssignmentSubmitedFile>();
                    var OldAssignmentFile = repoSubmitFile.GetAll().Where(x => x.AssignmentSubmited_ID == assignmentSubmitDto.AssignmentSubmitedID).ToList();

                    foreach (var item in OldAssignmentFile)
                    {
                        repoSubmitFile.HardDelete(item);
                    }
                    _unitOfWork.Commit();
                    List<AssignmentSubmitedFile> submitedFiles = new List<AssignmentSubmitedFile>();
                    foreach (var item in assignmentSubmitDto.Files)
                    {
                        submitedFiles.Add(new AssignmentSubmitedFile()
                        {
                            AssignmentSubmited_ID = assignmentSubmitDto.AssignmentSubmitedID,
                            Extension = item.Extension,
                            ContentType = item.ContentType,
                            Data = item.File
                        });
                    }
                    repoSubmitFile.AddRanges(submitedFiles);
                    _unitOfWork.Commit();
                }
                #endregion
                return responseDtos = new ResponseDto()
                {
                    Success = true,
                    Message = "Assignment has been Submited Successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssignmentSubmitedDto> GetStudentAssignmentDetail(int AssignmentID)
        {
            try
            {
                var ID = new SqlParameter("@AssignmentID", SqlDbType.Int).Value = (Convert.ToString(AssignmentID) ?? (object)DBNull.Value);
                assignmentSubmitedDtos = _unitOfWork.SpRepository<AssignmentSubmitedDto>("[dbo].[sp_GetAssimentSubmitedStudent] {0}", ID).ToList();
                return assignmentSubmitedDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AssignmentListDto> GetList(int PodID)
        {
            try
            {
                var p = new SqlParameter("@Pod_ID", SqlDbType.Int).Value = (Convert.ToString(PodID) ?? (object)DBNull.Value);
                assignmentListDtos = _unitOfWork.SpRepository<AssignmentListDto>("[dbo].[sp_AllPodAssignmentDetailByID] {0}", p).ToList();
                return assignmentListDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AssignmentDetailDto GetDetailByID(int AssignmentID)
        {
            try
            {
                var p = new SqlParameter("@AssignmentID", SqlDbType.Int).Value = (Convert.ToString(AssignmentID) ?? (object)DBNull.Value);
                assignmentDetailDtos = _unitOfWork.SpRepository<AssignmentDetailDto>("[dbo].[sp_AssignmentDetailByID] {0}", p).FirstOrDefault();
                var repoAssignment = _unitOfWork.GetRepository<AssignmentFile>();
                if (assignmentDetailDtos != null)
                {
                    assignmentDetailDtos.files = repoAssignment.GetAll().Where(o => o.Assignment_ID == AssignmentID).Select(r => new FileDto()
                    {
                        File = r.Data,
                        Extension = r.FileExt,
                        ContentType = r.ContectType
                    }).ToList();
                }
                return assignmentDetailDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

