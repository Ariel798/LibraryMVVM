using OOPFFinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IEditable
    {
        bool EditItem(LibraryItem m_selectedItem, int price, double discount, int stock);
    }
}
