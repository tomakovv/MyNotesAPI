using Application.Dto;
using Application.Dto.Note;

namespace Application.Interfaces
{
    public interface INoteService
    {
        ListNotesDto SearchByKeyword(string keyword);
        ListNotesDto GetAllNotes();
        NoteDto GetNoteById(int id);
        NoteDto AddNewNote(CreateNoteDto newNote);
        void UpdateNote( int id, UpdateNoteDto newNote);
        void DeleteNote(int id);
    }
}
