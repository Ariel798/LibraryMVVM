using OOPFFinalProject;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EditService : IEditable
    {
        readonly CollectionManager collectionManager = new CollectionManager();
        public bool EditItem(LibraryItem m_selectedItem, int price, double discount, int stock)
        {
            try
            {
                LibraryItem item = collectionManager[m_selectedItem.GetISBN];
                item.GetPrice = price;
                item.GetDiscount = discount;
                item.GetStock = stock;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
