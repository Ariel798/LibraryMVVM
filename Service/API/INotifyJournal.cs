using OOPFFinalProject;
using OOPFFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INotifyJournal
    {
        event Action notifySameISBN;
        event Action notifyWorngISBN;
    }
}
