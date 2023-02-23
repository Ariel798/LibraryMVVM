using OOPFFinalProject;
using OOPFFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IEditable
    {
        bool EditItem(ILibraryItem m_selectedItem,Book book);
    }
}
