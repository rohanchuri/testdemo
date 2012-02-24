using System;
using System.Collections.Generic;
using System.Text;
using MyBookShop.DAL;
using MyBookShop.Models;

namespace MyBookShop.BLL
{

    public static class PublisherManager
    {
        public static Publisher AddPublisher(Publisher publisher)
        {
            return PublisherService.AddPublisher(publisher);
        }

        public static void DeletePublisher(Publisher publisher)
        {
            PublisherService.DeletePublisher(publisher);
        }

        public static void DeletePublisherById(int id)
        {
            PublisherService.DeletePublisherById(id);
        }

		public static void ModifyPublisher(Publisher publisher)
        {
            PublisherService.ModifyPublisher(publisher);
        }
        
        public static IList<Publisher> GetAllPublishers()
        {
            return PublisherService.GetAllPublishers();
        }

        public static Publisher GetPublisherById(int id)
        {
            return PublisherService.GetPublisherById(id);
        }

    }
}
