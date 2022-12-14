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
        public void SupplyJournal(Journal journal)
        {
            double preDiscount = Calculate(journal.GetCategory);
            if (journal.GetDiscount < preDiscount)
                journal.GetDiscount = preDiscount;
            try
            {
                CollectionManager.HashTable.Add(journal.GetISBN, journal);
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
