using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;


namespace MyBookShop.BLL
{
    public static class SearchKeywordManager
    {
        public static SearchKeyword AddSearchKeyword(SearchKeyword searchKeyword)
        {
            return SearchKeywordService.AddSearchKeyword(searchKeyword);
        }

        public static void DeleteSearchKeyword(SearchKeyword searchKeyword)
        {
            SearchKeywordService.DeleteSearchKeyword(searchKeyword);
        }

        public static void DeleteSearchKeywordById(int id)
        {
            SearchKeywordService.DeleteSearchKeywordById(id);
        }

        public static void ModifySearchKeyword(SearchKeyword searchKeyword)
        {
            SearchKeywordService.ModifySearchKeyword(searchKeyword);
        }

        public static IList<SearchKeyword> GetAllSearchKeywords()
        {
            return SearchKeywordService.GetAllSearchKeywords();
        }

        public static SearchKeyword GetSearchKeywordById(int id)
        {
            return SearchKeywordService.GetSearchKeywordById(id);
        }

        /// <summary>
        /// 根据关键字搜索时,进行搜索计数
        /// </summary>
        /// <param name="keyword"></param>
        public static void Search(string keyword)
        {
            SearchKeyword skw = SearchKeywordService.GetKeyword(keyword);
            if (skw == null)
            {
                skw = new SearchKeyword();
                skw.Keyword = keyword;
                skw.SearchCount = 1;
                SearchKeywordService.AddSearchKeyword(skw);
            }
            else
            {
                skw.SearchCount++;
                SearchKeywordService.ModifySearchKeyword(skw);
            }
        }
        
    }
}
