﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OOPFFinalProject
{
    //The manager of the collection. 
    //Includes the filter method 'Run On Collection.
    //Managing the hash table as well for vertifing the ISBN uniquey nature.
    public class CollectionManager
    {
        static Hashtable hashtable;
        private static List<ILibraryItem> _catalog;
        public static List<ILibraryItem> FilterCollection { get; set; }
        public static Hashtable HashTable { get => hashtable; set => hashtable = value; }
        public static List<ILibraryItem> GetCatalog { get => _catalog; set => _catalog = value; }
        public static List<ILibraryItem> RunOnCollection(int iSBN, string nameFilter, double discount, int price, int stock, Category categories, bool iSBNFlag, bool discountFlag, bool priceFlag, bool stockFlag)
        {
            var filteredList = new List<ILibraryItem>();
            bool check = true;
            foreach (var item in _catalog)
            {
                if (iSBNFlag)
                {
                    if (!(item.GetISBN == iSBN))
                    {
                        check = false;
                    }
                }
                if (nameFilter != null && !item.GetName.Contains(nameFilter))
                {
                    check = false;
                }
                if (discountFlag)
                {
                    if (!(item.GetDiscount <= discount))
                    {
                        check = false;
                    }
                }
                if (priceFlag)
                {
                    if (!(item.GetPrice >= price))
                    {
                        check = false;
                    }
                }
                if (stockFlag)
                {
                    if (!(item.GetStock <= stock))
                    {
                        check = false;
                    }
                }
                if (!(item.GetCategory == categories))
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


