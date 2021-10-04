using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.NotesDto
{
    public class NotesRequestDto
    {
        public NotesRequestDto()
        {
            notesFileRequestDtos = new List<NotesFileRequestDto>();
        }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pod Id is required")]
        public int Pod_ID { get; set; }
        public List<NotesFileRequestDto> notesFileRequestDtos { get; set; }

    }  
}
