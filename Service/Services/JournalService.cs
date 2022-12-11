using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class JournalService: IJournal,INotifyJournal
    {
        public event Action RefreshEvent;
        public event Action notifySameISBN;
        public event Action notifyWorngISBN;
        public void SupplyJournal(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberOfLegion)
        {
            double preDiscount = Calculate(category);
            if (discount < preDiscount)
                discount = preDiscount;
            Journal journal = new Journal(iSBN, name, authorName, publisher, published, category, price, discount, stock, numberOfLegion);
            try
            {
                CollectionManager.HashTable.Add(iSBN, journal);
                CollectionManager.GetCatalog.Add(journal);
                RefreshEvent?.Invoke();
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
