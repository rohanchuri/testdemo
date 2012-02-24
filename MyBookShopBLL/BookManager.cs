using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static class BookManager
    {
        public static void DeleteBook(Book book)
        {
            BookService.DeleteBook(book);
        }

        public static void DeleteBookById(int id)
        {
            BookService.DeleteBookById(id);
        }

        public static void ModifyBook(Book book)
        {
            BookService.ModifyBook(book);
        }

        public static IList<Book> GetAllBooks()
        {
            return BookService.GetAllBooks();
        }

        public static Book GetBookById(int id)
        {
            return BookService.GetBookById(id);
        }

        /// <summary>
        /// 查询图书列表
        /// 包含了分类的查询
        /// 和有无排序的条件
        /// </summary>
        /// <param name="categoryId">查询条件：分类。小于1时代表不分类</param>
        /// <param name="order">排序条件，为空则不排序</param>
        /// <returns></returns>
        public static IList<Book> GetOrderedSmallBooksByCategoryId(int categoryId, string order)
        {
            return BookService.GetPartialBooksBySql(categoryId, order);
        }
        /// <summary>
        /// 搜索图书
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static IList<Book> SearchBooks(string keyword,string order)
        {
            return BookService.SearchBooks(keyword,order);
        }

        /// <summary>
        /// 更新图书分类
        /// </summary>
        /// <param name="sbs"></param>
        /// <param name="catagory"></param>
        /// <returns></returns>
        public static void ModifyCatagory(string ids, string catagory)
        {
            BookService.ModifyCatagory(ids, catagory);
        }
        /// <summary>
        /// 专为图书修改页提供的图书更新
        /// </summary>
        /// <param name="title"></param>
        /// <param name="Publisherid"></param>
        /// <param name="WordsCount"></param>
        /// <param name="AurhorDescription"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="author"></param>
        /// <param name="TOC"></param>
        /// <param name="PublishDate"></param>
        /// <param name="ContentDescription"></param>
        /// <param name="editorComment"></param>
        /// <param name="id"></param>
        public static void ModifyBook(string title, int Publisherid, int WordsCount, string AurhorDescription, decimal UnitPrice, string author, string TOC, DateTime PublishDate, string ContentDescription, string editorComment, int id)
        {
            if (AurhorDescription == null)
                AurhorDescription = "";
            if (ContentDescription == null)
                ContentDescription = "";
            if (ContentDescription == null)
                ContentDescription = "";
            if (editorComment == null)
                editorComment = "";
            if (ContentDescription == null)
                ContentDescription = "";
            if (editorComment == null)
                editorComment = "";
            if (TOC == null)
                TOC = "";

            Book book = BookService.GetBookById(id);
            book.Title = title;
            book.UnitPrice = UnitPrice;
            book.Author = author;
            book.TOC = TOC;
            book.Publisher = PublisherService.GetPublisherById(Publisherid);
            book.WordsCount=WordsCount;           
            book.AurhorDescription = AurhorDescription;
            book.PublishDate = PublishDate;
            book.ContentDescription = ContentDescription;
            book.EditorComment = editorComment;
            BookService.ModifyBook(book);
        }

        /// <summary>
        /// 专为图书修改页提供的添加图书
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isbn"></param>
        /// <param name="Publisherid"></param>
        /// <param name="WordsCount"></param>
        /// <param name="AurhorDescription"></param>
        /// <param name="UnitPrice"></param>
        /// <param name="author"></param>
        /// <param name="TOC"></param>
        /// <param name="PublishDate"></param>
        /// <param name="ContentDescription"></param>
        /// <param name="editorComment"></param>
        public static void AddBook(string title,string isbn, int Publisherid, int WordsCount, string AurhorDescription, decimal UnitPrice, string author, string TOC, DateTime PublishDate, string ContentDescription, string editorComment)
        {
            Book book = new Book();
            book.Category = CategoryService.GetCategoryById(1);
            book.Title = title;
            book.ISBN = isbn;
            book.UnitPrice = UnitPrice;
            book.Author = author;
            book.TOC = TOC;
            book.Publisher = PublisherService.GetPublisherById(Publisherid);
            book.WordsCount = WordsCount;
            book.AurhorDescription = AurhorDescription;
            book.PublishDate = PublishDate;
            book.ContentDescription = ContentDescription;
            book.EditorComment = editorComment;
            book.Clicks = 0;
            book.Votes = 0;
            book.TotalRating = 0;
            AddNewBook(book);
        }
        
        public static Book AddNewBook(Book book)
        {
            if (BookService.GetBookByISBN(book.ISBN) == null)
            {
                return BookService.AddBook(book);
            }
            else
            {
                return null;
            }
        }

    }
}
