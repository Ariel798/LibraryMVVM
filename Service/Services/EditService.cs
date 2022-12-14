using OOPFFinalProject;
using OOPFFinalProject.Models;
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
        public bool EditItem(ILibraryItem m_selectedItem, Book book)
        {
            try
            {
                ILibraryItem item = collectionManager[m_selectedItem.GetISBN];
                item.GetPrice = book.GetPrice;
                item.GetDiscount = book.GetDiscount;
                item.GetStock = book.GetStock;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
