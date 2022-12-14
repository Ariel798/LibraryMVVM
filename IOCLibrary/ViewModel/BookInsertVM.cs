using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IOCLibrary
{
    public class BookInsertVM : ViewModelBase
    {
        readonly IBook ibook;
        readonly INotifyBook _notify;
        #region flags
        private bool horrorFlag;
        private bool fictionFlag;
        private bool romanceFlag;
        private bool kitchenFlag;
        #endregion
        #region Properties
        public bool HorrorFlag { get { return horrorFlag; } set { horrorFlag = value; } }
        public bool FictionFlag { get { return fictionFlag; } set { fictionFlag = value; } }
        public bool RomanceFlag { get { return romanceFlag; } set { romanceFlag = value; } }
        public bool KitchenFlag { get { return kitchenFlag; } set { kitchenFlag = value; } }
        public string AuthorDiscount { get; set; }
        public string PublisherDiscount { get; set; }
        public int GetISBN { get; set; }
        public string GetName { get; set; }
        public string GetAuthor { get; set; }
        public string GetPublisher { get; set; }
        public DateTime GetPublishedDate { get; set; }
        public int GetPrice { get; set; }
        public int GetStock { get; set; }
        public int GetNumberInSeries { get; set; }
        #endregion
        public RelayCommand AddBookCommand { get; set; }
        public BookInsertVM(IBook ibook, INotifyBook notify)
        {
            this.ibook = ibook;
            _notify = notify;
            AddBookCommand = new RelayCommand(AddBookToList);
            _notify.notifySameISBN += ShowErrorMessageBox;
            _notify.notifyWorngISBN += ShowMinusISBNMessege;
        }
        private void AddBookToList()
        {
            try
            {
                Category Categories = CalculateCategory();
                double discountMax = CalculateDiscount();
                var book = new Book { GetISBN = this.GetISBN, GetName = this.GetName, GetAuthor = this.GetAuthor, GetPublisher = GetPublisher, GetPublishedDate = GetPublishedDate.ToString("MMMM d, yyyy"), GetCategory = Categories, GetPrice = GetPrice, GetDiscount = discountMax, GetStock = GetStock, NumberInSeries = GetNumberInSeries };
                ibook.SupplyBook(book);
            }
            catch (Exception)
            {
                throw;
            }
        }
        private Category CalculateCategory()
        {
            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            if (horrorFlag)
            {
                first = 2;
            }
            if (fictionFlag)
            {
                second = 4;
            }
            if (romanceFlag)
            {
                third = 8;
            }
            if (kitchenFlag)
            {
                fourth = 16;
            }
            int sum = first + second + third + fourth;
            Category Categories = (Category)sum;
            return Categories;
        }
        private double CalculateDiscount()
        {
            try
            {
                double discountAuthor = double.Parse(AuthorDiscount);
                double discountPublisher = double.Parse(PublisherDiscount);
                double finalMax = Math.Max(discountAuthor, discountPublisher);
                return finalMax;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private void ShowErrorMessageBox()
        {
            MessageBox.Show("Cannot add two product with the same ISBN!", $"Notice!");
        }
        private void ShowMinusISBNMessege()
        {
            MessageBox.Show("The ISBN cannot be a negative number!", $"Notice!");
        }
    }
}
