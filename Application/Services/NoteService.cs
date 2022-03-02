using Application.Dto;
using Application.Dto.Note;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public NoteDto AddNewNote(CreateNoteDto newNote)
        {
            if (string.IsNullOrEmpty(newNote.Title))
            {
                throw new Exception("Note cannot be ampty");
            }
            var category = _categoryRepository.GetById(newNote.CategoryId);
            if (category == null)
            {
                throw new Exception("Category does not exist");
            }
            var note = _mapper.Map<Note>(newNote);
            note.Detail = new NoteDetail()
            {
                Created = DateTime.Now,
                LastModified = DateTime.Now
            };
            _noteRepository.Add(note);
            return _mapper.Map<NoteDto>(note);
        }

        public void DeleteNote(int id)
        {
            var note = _noteRepository.GetById(id);
            _noteRepository.Delete(note);
        }

        public ListNotesDto GetAllNotes()
        {
            var notes = _noteRepository.GetAll();
            return _mapper.Map<ListNotesDto>(notes);
        }

        public ListNotesDto SearchByKeyword(string keyword)
        {
            keyword = keyword.ToLower();
            var notes = _noteRepository.GetAll()
                .Where(x => x.Title.ToLowerInvariant().Contains(keyword)|| x.Content.ToLowerInvariant().Contains(keyword));

            return _mapper.Map<ListNotesDto>(notes);

        }
        public NoteDto GetNoteById(int id)
        {
            var note = _noteRepository.GetById(id);
            return _mapper.Map<NoteDto>(note);
        }


        public void UpdateNote(int id, UpdateNoteDto newNote)
        {
            if (string.IsNullOrEmpty(newNote.Title))
            {
                throw new Exception("Note cannot be ampty");
            }

            var category = _categoryRepository.GetById(newNote.CategoryId);
            if (category == null)
            {
                throw new Exception("Category does not exist");
            }
            var existingNote = _noteRepository.GetById(id);
            var updatedNote = _mapper.Map(newNote, existingNote);
            updatedNote.Detail.LastModified = DateTime.Now;
            _noteRepository.Update(updatedNote);
        }
    }
}
