using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service.API;
using System;
using System.Linq;

namespace Service
{
    public class BookService : IBook, INotifyBook
    {
        public event Action RefreshEvent;
        public event Action notifySameISBN;
        public event Action notifyWorngISBN;
        public void SupplyBook(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberInSeries)
        {
            double preDiscount = Calculate(category);
            if (discount < preDiscount)
                discount = preDiscount;
            Book book = new Book(iSBN, name, authorName, publisher, published, category, price, discount, stock, numberInSeries);
            try
            {
                CollectionManager.HashTable.Add(iSBN, book);
                CollectionManager.GetCatalog.Add(book);
                RefreshEvent?.Invoke();
            }
            catch (InvalidOperationException a)
            {
                return;
            }
            catch (ArgumentException ex)
            {
                notifySameISBN?.Invoke();
            }
            catch (Exception)
            {
                notifyWorngISBN?.Invoke();
                return;
            }
        }
        double Calculate(Category category)
        {
            if (category == Category.Romance)
            {
                return 15;
            }
            else if (category == Category.Horror)
            {
                return 10;
            }
            else if (category == Category.Kitchen)
            {
                return 7;
            }
            else if (category == Category.Fiction)
            {
                return 5;
            }
            return 0;
        }
    }
}
