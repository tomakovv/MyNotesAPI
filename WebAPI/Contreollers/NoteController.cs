using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Contreollers
{
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            this._noteService = noteService;
        }
        [SwaggerOperation(Summary ="get all items")]
        [HttpGet]

        public IActionResult Get()
        {
            var notes = _noteService.GetAllNotes();
            return Ok(notes);
        }

        [HttpGet("Search/{keyword}")]

        public IActionResult Search(string keyword)
        {
            var notes = _noteService.SearchByKeyword(keyword);
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _noteService.GetNoteById(id);
            if (note == null)
            {
                return NotFound();
            }    
            return Ok(note);
        }

        [HttpPost]
        public IActionResult Create(CreateNoteDto newNote)
        {
            var note = _noteService.AddNewNote(newNote);
            return Created($"api/notes/{note.Id}", note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,UpdateNoteDto updateNote)
        {
            _noteService.UpdateNote(id, updateNote);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return NoContent();
        }
    }

}
