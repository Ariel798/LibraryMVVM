using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IOCLibrary.Context;
using OOPFFinalProject;
using OOPFFinalProject.Interfaces;
using OOPFFinalProject.Models;
using Service;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IOCLibrary
{
    //Class for the journal insertion user control.
    public class JournalInsertMVM : ViewModelBase
    {
        #region Field&Properties
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
        readonly ICalculator calculator;
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
        #endregion
        public JournalInsertMVM(IJournal journal,INotifyJournal notify,ICalculator calculator)
        {
            _journal = journal;
            _notify = notify;
            this.calculator = calculator;
            AddJournalCommand = new RelayCommand(AddJournalToList);
            _notify.notifySameISBN += ShowErrorMessageBox;
            _notify.notifyWorngISBN += ShowMinusISBNMessege;
        }
        private void AddJournalToList()
        {
            Category Categories = calculator.CalculateCategory(horrorFlag, fictionFlag, romanceFlag, kitchenFlag);
            double discountMax = calculator.CalculateDiscount(AuthorDiscount,PublisherDiscount);
            var journal = new Journal { GetISBN = this.GetISBN, GetName = this.GetName, GetAuthor = this.GetAuthor, GetPublisher = GetPublisher, GetPublishedDate = GetPublishedDate.ToString("MMMM d, yyyy"), GetCategory = Categories, Price = GetPrice, Discount = discountMax, Stock = GetStock, NumberOfLegion = GetNumberOfLegion };
            _journal.SupplyJournal(journal);
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
