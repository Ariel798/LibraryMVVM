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
        int Price { get; set; }
        double Discount { get; set; }
        int Stock { get; set; }
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
