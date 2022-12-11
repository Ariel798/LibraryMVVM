using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface INotifyBook
    {
        event Action notifySameISBN;
        event Action notifyWorngISBN;
    }
}
