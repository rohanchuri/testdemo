using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.Models;
using MyBookShop.DAL;

namespace MyBookShopBLL
{
    public static class CategoryManager
    {
        public static Category AddCategory(Category category)
        {
            return CategoryService.AddCategory(category);
        }

        public static void DeleteCategory(Category category)
        {
            CategoryService.DeleteCategory(category);
        }

        public static void DeleteCategoryById(int id)
        {
            CategoryService.DeleteCategoryById(id);
        }

        public static void ModifyCategory(Category category)
        {
            CategoryService.ModifyCategory(category);
        }

        public static IList<Category> GetAllCategories()
        {
            return CategoryService.GetAllCategories();
        }

        public static Category GetCategoryById(int id)
        {
            return CategoryService.GetCategoryById(id);
        }

        /// <summary>
        /// 修改图书分类名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public static void ModifyCategory(int id,string name)
        {
            Category category = CategoryService.GetCategoryById(id);
            if (category != null)
            {
                category.Name = name;
                CategoryService.ModifyCategory(category);
            }
        }
    }
}
