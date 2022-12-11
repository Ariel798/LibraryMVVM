using OOPFFinalProject;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DataFilterService:IFilter
    {
        public event Action RefreshEvent;
        public void ReturnFilteredCollection(int iSBN, string nameFilter, double discount, int price, int stock, Category Categories, bool iSBNFlag, bool discountFlag, bool priceFlag, bool stockFlag)
        {
            CollectionManager.FilterCollection = CollectionManager.RunOnCollection(iSBN, nameFilter, discount, price, stock, Categories, iSBNFlag, discountFlag, priceFlag, stockFlag);
            RefreshEvent?.Invoke();
        }
        public void ReturnFullCollection()
        {
            CollectionManager.FilterCollection = CollectionManager.GetCatalog;
            RefreshEvent?.Invoke();
        }
    }
}
