using OOPFFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IFilter
    {
        event Action RefreshEvent;
        void ReturnFilteredCollection(int iSBN, string nameFilter, double discount, int price, int stock, Category Categories, bool iSBNFlag, bool discountFlag, bool priceFlag, bool stockFlag);
        void ReturnFullCollection();
    }
}
