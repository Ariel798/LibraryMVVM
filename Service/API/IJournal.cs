using OOPFFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IJournal
    {
        event Action RefreshEvent;
        void SupplyJournal(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberOfLegion);
    }
}
