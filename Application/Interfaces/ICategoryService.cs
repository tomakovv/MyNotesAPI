
using Application.Dto.Category;


namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
        CategoryDto AddNewCategory(CreateCategoryDto categoryDto);
        void UpdateCategory(int id,UpdateCategoryDto updateCategory);
        void DeleteCategory(int id);
    }
}
