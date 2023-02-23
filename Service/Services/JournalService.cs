using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service.IServices;
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
        public event Action<Journal> AddEvent;
        public void SupplyJournal(Journal journal)
        {
            double preDiscount = Calculate(journal.GetCategory);
            if (journal.Discount < preDiscount)
                journal.Discount = preDiscount;
            try
            {
                CollectionManager.HashTable.Add(journal.GetISBN, journal);
                CollectionManager.GetCatalog.Add(journal);
                RefreshEvent?.Invoke();
                AddEvent?.Invoke(journal);
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
