
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyNotesContext _context;

        public CategoryRepository(MyNotesContext context)
        {
            _context = context;
        }

        public Category Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(e => e.Id == id);
            return category;
        }

        public void Update(Category category)
        {
           _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
