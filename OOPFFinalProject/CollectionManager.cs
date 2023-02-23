using OOPFFinalProject.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOPFFinalProject
{
    //The manager of the collection. 
    //Includes the filter method 'Run On Collection.
    //Holds the hash table for vertifing the ISBN uniquey nature.
    public class CollectionManager
    {
        static Hashtable hashtable;
        private static List<ILibraryItem> _catalog;
        public static List<ILibraryItem> FilterCollection { get; set; }
        public static Hashtable HashTable { get => hashtable; set => hashtable = value; }
        public static List<ILibraryItem> GetCatalog { get => _catalog; set => _catalog = value; }
        public static List<ILibraryItem> Filter(FilterItem filterItem)
        {
            var filteredList = new List<ILibraryItem>();
            bool check = true;
            foreach (var item in _catalog)
            {
                if (filterItem.filterISBNFlag)
                {
                    if (!(item.GetISBN == filterItem.GetISBN))
                    {
                        check = false;
                    }
                }
                if (filterItem.GetName != null && !item.GetName.ToLower().Contains(filterItem.GetName))
                {
                    check = false;
                }
                if (filterItem.filterDiscountFlag)
                {
                    if (!(item.Discount <= filterItem.Discount))
                    {
                        check = false;
                    }
                }
                if (filterItem.filterPriceFlag)
                {
                    if (!(item.Price >= filterItem.Price))
                    {
                        check = false;
                    }
                }
                if (filterItem.filterStockFlag)
                {
                    if (!(item.Stock <= filterItem.Stock))
                    {
                        check = false;
                    }
                }
                if (!(item.GetCategory == filterItem.GetCategory))
                {
                    check = false;
                }
                if (check)
                {
                    filteredList.Add(item);
                }
                check = true;
            }
            return filteredList;
        }
        public ILibraryItem this[int iSBN]
        {
            get
            {
                return _catalog.Single(item => item.GetISBN == iSBN);
            }
        }
        public CollectionManager()
        {
            _catalog = new List<ILibraryItem>();
            FilterCollection = GetCatalog;
            hashtable = new Hashtable();
        }

    }
}


