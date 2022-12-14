using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace IOCLibrary.Interfaces
{
    public interface ILibraryItem
    {
        int ISBN { get; set; }
        string Name { get; set; }
        string AuthorName { get; set; }
        string Publisher { get; set; }
        string Category { get; set; }
        int Price { get; set; }
        int Discount { get; set; }
        string Stock { get; set; }
        string TypeOfItem { get; set; }
    }
}
