using System.Collections.Generic;
using System.Linq;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly TaskDbContext context;
        public CategoryRepository()
        {
            context = new TaskDbContext();
        }

        // This method should be used to delete category details from database based upon category id
        public int DeleteCategory(int categoryId)
        {
            
        }

        // This method should be used to get all categories from database based upon user's email
        public IReadOnlyList<Category> GetAllCategories(string email)
        {
            
        }

        // This method should be used to get category details based upon category id
        public Category GetCategoryById(int categoryId)
        {
            
        }

        // This method should be used to save category details into database
        public int SaveCategory(Category category)
        {
            
        }
    }
}