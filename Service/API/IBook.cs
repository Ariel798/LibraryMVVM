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
        event Action<Book> AddEvent;
        void SupplyBook(Book book);
    }
}
