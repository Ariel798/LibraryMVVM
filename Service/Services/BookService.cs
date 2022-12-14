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
        public event Action<Book> AddEvent;
        //Change method name to supply to Collection View Model
        public void SupplyBook(Book book)
        {
            double preDiscount = CalculateDiscountByCategory(book.GetCategory);
            bool resetDiscount = book.GetDiscount < preDiscount;
            if (resetDiscount) book.GetDiscount = preDiscount;

            try
            {
                CollectionManager.HashTable.Add(book.GetISBN, book);
                CollectionManager.GetCatalog.Add(book);
                RefreshEvent?.Invoke();
                AddEvent?.Invoke(book);
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

        //Add booleans
        double CalculateDiscountByCategory(Category category)
        {
            bool discountForHorror = category == Category.Romance;
            if (discountForHorror)
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
