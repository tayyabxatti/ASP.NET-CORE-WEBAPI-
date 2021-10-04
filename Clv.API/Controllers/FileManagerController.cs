using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Clv.Models.Entities.FileManager;
using Clv.Models.Entities.TeacherEntity;
using Clv.Services.FileManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileManagerService _fileManagerService;


        public FileManagerController(IFileManagerService fileManagerService)
        {
            _fileManagerService = fileManagerService;

        }
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync()
        {
            var files = Request.Form.Files;
            var Note = Request.Form["FileTable"].ToString();
            var RequestId = Request.Form["Id"].ToString();

            if (files.Any(f => f.Length == 0))
            {
                return BadRequest();
            }
            foreach (var file in files)
            {
                //Stream filereader;
                byte[] completeFile;
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString().Trim('"');
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    completeFile = memoryStream.ToArray();
                };

                if (Note == "ProfileImage")
                {
                    ProfileImage profileImage = new ProfileImage();
                    profileImage.Profile_Image_Id = 0;
                    profileImage.Content = completeFile;
                    profileImage.Image_Name = fileName;
                    await _fileManagerService.AddProfileImage(profileImage);
                    return Ok(profileImage);
                }

                if (Note == "TecherCv")
                {
                    TeacherCv teacher = new TeacherCv();
                    teacher.FileName = fileName;
                    teacher.Content = completeFile;
                    await _fileManagerService.AddTecherCv(teacher);
                    return Ok(teacher);
                }

                return Ok();
            }
            return Ok("done");

        }

    }
}