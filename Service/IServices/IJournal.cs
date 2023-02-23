using OOPFFinalProject;
using OOPFFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IJournal
    {
        event Action RefreshEvent;
        event Action<Journal> AddEvent;
        void SupplyJournal(Journal journal);
    }
}
