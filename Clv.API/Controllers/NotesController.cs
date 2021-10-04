using Clv.Models.ApiModelsDto.NotesDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.Entities.NotesEntity;
using Clv.Services.Notes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        List<NoteDto> noteDtos;
        NoteDto noteDto;
        private Response response;
        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
            noteDtos = new List<NoteDto>();
            noteDto = new NoteDto();
        }

        [HttpPost]
        public IActionResult Post(NotesRequestDto notesRequest)
        {
            response = _notesService.Create(notesRequest);
            return Ok(response);
        }

        [HttpGet]
        [Route("DownloadFile/{fileID}")]
        public FileResult DownLoadFile(int NotesFileId)
        {
            var result = _notesService.GetFile(NotesFileId);
            return File(result.Data, result.ContentType, result.FileName);
        }


        [HttpGet]
        [Route("{PodId}")]
        public IActionResult GetNotesList(int PodId)
        {
            if (PodId <= 0)
            {
                return BadRequest("Pod id is required");
            }
            noteDtos = _notesService.GetNotesList(PodId);
            if (noteDtos.Count > 0)
                return Ok(noteDtos);
            else
                return NotFound(noteDtos);
        }


        [HttpPut]
        [Route("{PodId}")]
        public IActionResult Delete(int NotesID)
        {
            if (NotesID <= 0)
            {
                return BadRequest("Notes id is required");
            }

            response = _notesService.Delete(NotesID);

            if (response.StatusCode == "Ok")
                return Ok(response);
            else
                return StatusCode(500, response);
        }

        [HttpGet]
        [Route("GetNotesDetailByID/{NotestId}")]
        public IActionResult GetNotesDetailByID(int NotestId)
        {
            if (NotestId <= 0)
            {
                return BadRequest("Notes id is required");
            }
            noteDto = _notesService.GetNotesByID(NotestId);
            if (noteDto != null)
                return Ok(noteDto);
            else
                return NotFound(noteDto);
        }
    }
}
