using OOPFFinalProject;
using OOPFFinalProject.Objects;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DataFilterService:IFilter
    {
        public event Action RefreshEvent;
        public void ReturnFilteredCollection(FilterItem filterItem)
        {
            CollectionManager.FilterCollection = CollectionManager.Filter(filterItem);
            RefreshEvent?.Invoke();
        }
        public void ReturnFullCollection()
        {
            CollectionManager.FilterCollection = CollectionManager.GetCatalog;
            RefreshEvent?.Invoke();
        }
    }
}
