using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject
{
    public abstract class LibraryItem
    {
        #region Fields
        readonly int _iSBN;
        readonly string _name;
        readonly string _authorName;
        readonly string _publisher;
        readonly DateTime _published;
        readonly Category _category;
        int _price;
        double _discount;
        int _stock;

        #endregion
        #region Properties
        public int GetISBN { get => _iSBN; }
        public string GetName { get => _name; }
        public string GetAuthor { get => _authorName; }
        public string GetPublisher { get => _publisher; }
        public DateTime GetPublishedDate { get => _published; }
        public Category GetCategory { get => _category; }
        public int GetPrice { get => _price; set => _price = value; }
        public double GetDiscount { get => _discount; set => _discount = value; }
        public int GetStock { get => _stock; set => _stock = value; }
        #endregion
        public LibraryItem(int iSBN, string name, string authorName, string publisher, DateTime published, Category category, int price, double discount, int stock)
        {
            if (iSBN < 0)
                throw new InvalidOperationException("ISBN");
            _iSBN = iSBN;
            _name = name;
            _authorName = authorName;
            _publisher = publisher;
            _published = published;
            _category = category;
            _price = price;
            _discount = discount;
            _stock = stock;
        }
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
