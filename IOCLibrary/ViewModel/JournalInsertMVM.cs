using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOPFFinalProject;
using Service;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IOCLibrary
{
    //Class for the journal insertion user control.
    public class JournalInsertMVM : ViewModelBase
    {
        private bool horrorFlag;
        private bool fictionFlag;
        private bool romanceFlag;
        private bool kitchenFlag;
        public bool HorrorFlag { get { return horrorFlag; } set { horrorFlag = value; } }
        public bool FictionFlag { get { return fictionFlag; } set { fictionFlag = value; } }
        public bool RomanceFlag { get { return romanceFlag; } set { romanceFlag = value; } }
        public bool KitchenFlag { get { return kitchenFlag; } set { kitchenFlag = value; } }
        readonly IJournal _journal;
        readonly INotifyJournal _notify;
        public int GetISBN { get; set; }
        public string GetName { get; set; }
        public string GetAuthor { get; set; }
        public string GetPublisher { get; set; }
        public DateTime GetPublishedDate { get; set; }
        public int GetPrice { get; set; }
        public string AuthorDiscount { get; set; }
        public string PublisherDiscount { get; set; }
        public int GetStock { get; set; }
        public int GetNumberOfLegion { get; set; }
        public RelayCommand AddJournalCommand { get; set; }
        public JournalInsertMVM(IJournal journal,INotifyJournal notify)
        {
            _journal = journal;
            _notify = notify;
            AddJournalCommand = new RelayCommand(AddJournalToList);
            _notify.notifySameISBN += ShowErrorMessageBox;
            _notify.notifyWorngISBN += ShowMinusISBNMessege;
        }
        private void AddJournalToList()
        {
            Category Categories = CalculateCategory();
            double discountMax = CalculateDiscount();
            _journal.SupplyJournal(GetISBN, GetName, GetAuthor, GetPublisher, GetPublishedDate, Categories, GetPrice, discountMax, GetStock, GetNumberOfLegion);
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
