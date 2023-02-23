using OOPFFinalProject;
using OOPFFinalProject.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IFilter
    {
        event Action RefreshEvent;
        void ReturnFilteredCollection(FilterItem filterItem);
        void ReturnFullCollection();
    }
}
