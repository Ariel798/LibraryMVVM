using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Models
{
    public class Book : LibraryItem
    {
        readonly int _numberInSeries;
        public int NumberInSeries { get => _numberInSeries; }
        public Book(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock, int numberInSeries) : base(iSBN, name, authorName, publisher, published, category, price, discount, stock)
        {
            _numberInSeries = numberInSeries;
        }
    }
}
