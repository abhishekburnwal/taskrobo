using System;
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
            int result = 0;
            Category objCategory = new Category();
            try
            {
                objCategory = context.Categories.Where(p => p.CategoryId == categoryId).FirstOrDefault();
                if (objCategory != null)
                {
                    context.Categories.Remove(objCategory);
                    context.SaveChanges();
                    result = 1;
                }
            }
            catch (Exception ex)
            {
                return result = 0;
            }
            return result;
        }

        // This method should be used to get all categories from database based upon user's email
        public IReadOnlyList<Category> GetAllCategories(string email)
        {
            List<Category> objCategoryList = new List<Category>();
            try
            {
                objCategoryList = context.Categories.ToList();
                return objCategoryList;
            }
            catch (Exception ex)
            {
                return objCategoryList;
            }
        }

        // This method should be used to get category details based upon category id
        public Category GetCategoryById(int categoryId)
        {
            Category objCategory = new Category();
            try
            {
                objCategory = context.Categories.Where(p => p.CategoryId == categoryId).FirstOrDefault();
                return objCategory;
            }
            catch (Exception ex)
            {
                return objCategory;
            }
        }

        // This method should be used to save category details into database
        public int SaveCategory(Category category)
        {
            int result = 0;
            try
            {
                context.Categories.Add(category);
                context.SaveChanges();
                result = 1;
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }
    }
}