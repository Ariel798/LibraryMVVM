using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Models
{
    public class Journal : LibraryItem
    {
        readonly int _numberOfLegion;
        public int NumberOfLegion { get => _numberOfLegion; }
        public Journal(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberOfLegion) : base(iSBN, name, authorName, publisher, published, category, price, discount, stock)
        {
            _numberOfLegion = numberOfLegion;
        }
    }
}
