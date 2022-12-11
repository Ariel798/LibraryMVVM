using OOPFFinalProject;
using OOPFFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IBook
    {
        event Action RefreshEvent;
        void SupplyBook(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberInSeries);
    }
}
