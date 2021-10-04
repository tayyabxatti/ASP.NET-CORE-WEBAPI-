using Clv.Models.ApiModelsDto.NotesDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Notes
{
    public interface INotesService
    {
        Response Create(NotesRequestDto requestDto);
        Response Delete(int NotesId);
        List<NoteDto> GetNotesList(int PodID);
        NoteDto GetNotesByID(int NoteID);

        NotesFileRequestDto GetFile(int FileID);
    }
}
