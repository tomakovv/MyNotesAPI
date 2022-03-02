
using Application.Dto.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public CategoryDto AddNewCategory(CreateCategoryDto newCategory)
        {
            if (string.IsNullOrEmpty(newCategory.Name))
            {
                throw new ArgumentNullException(nameof(newCategory.Name));
            }

            var categoryWithSameName = _categoryRepository.GetAll().SingleOrDefault(x => x.Name == newCategory.Name);
            if (categoryWithSameName != null)
            {
                throw new Exception("Category with same name already exists");
            }
            var category = _mapper.Map<Category>(newCategory);
            _categoryRepository.Add(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public void DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public void UpdateCategory(int id, UpdateCategoryDto newCategory)
        {
            if (string.IsNullOrEmpty(newCategory.Name))
            {
                throw new Exception("catagory can not have empty name");
            }
            var existingCategory = _categoryRepository.GetById(id);
            var updatedCategory = _mapper.Map(newCategory, existingCategory);
            _categoryRepository.Update(updatedCategory);
        }
    }
}
