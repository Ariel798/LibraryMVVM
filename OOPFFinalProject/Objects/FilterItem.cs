using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Objects
{
    public class FilterItem : ILibraryItem
    {
        public int GetISBN { get; set; }
        public string GetName { get; set; }
        public string GetAuthor { get; set; }
        public string GetPublisher { get; set; }
        public string GetPublishedDate { get; set; }
        public Category GetCategory { get; set; }
        public int Price { get; set; }
        public double Discount { get; set; }
        public int Stock { get; set; }
        public bool filterISBNFlag { get; set; }
        public bool filterDiscountFlag { get; set; }
        public bool filterStockFlag { get; set; }
        public bool filterPriceFlag { get; set; }
    }
}
