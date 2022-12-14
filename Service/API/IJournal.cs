using OOPFFinalProject;
using OOPFFinalProject.Models;
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
        void SupplyJournal(Journal journal);
    }
}
