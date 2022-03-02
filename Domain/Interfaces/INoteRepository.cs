using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        IQueryable<Note> GetAll();
        Note GetById(int id);

        Note Add(Note note);

        void Update(Note note);

        void Delete(Note note);
    }
}
