using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class NoteRepository : INoteRepository
    {
        private readonly MyNotesContext _context;
        public NoteRepository(MyNotesContext context)
        {
            _context = context;
        }

        public Note Add(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void Delete(Note note)
        {
            _context.Remove(note);
            _context.SaveChanges();
        }

        public IQueryable<Note> GetAll()
        {
            return _context.Notes
                .Include(x => x.Detail)
                .Include(x => x.Category);
        }

        public Note GetById(int id)
        {
            return _context.Notes
                .Include(x => x.Detail)
                .Include(x => x.Category)
                .SingleOrDefault(e => e.Id == id);
        }




        public void Update(Note note)
        {
            _context.Update(note);
            _context.SaveChanges();

        }
    }
}