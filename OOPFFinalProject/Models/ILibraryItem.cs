using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject
{
    public interface ILibraryItem
    {
        #region Properties
        int GetISBN { get; set; }
        string GetName { get; set; }
        string GetAuthor { get; set; }
        string GetPublisher { get; }
        string GetPublishedDate { get; }
        Category GetCategory { get; }
        int GetPrice { get; set; }
        double GetDiscount { get; set; }
        int GetStock { get; set; }
        #endregion
    }
    [Flags]
    public enum Category
    {
        Horror = 2,
        Fiction = 4,
        Romance = 8,
        Kitchen = 16
    }
}
