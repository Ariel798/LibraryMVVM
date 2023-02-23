using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service.IServices;
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
                item.Price = book.Price;
                item.Discount = book.Discount;
                item.Stock = book.Stock;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
