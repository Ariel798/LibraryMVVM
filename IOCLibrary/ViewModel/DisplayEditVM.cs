using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IOCLibrary.DataBase;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IOCLibrary
{
    //Summary
    //Class for the observable list.
    //In charge of the edit item controls as well.
    public class DisplayEditVM : ViewModelBase, INotifyPropertyChanged
    {
        readonly IBook _admin;
        readonly IFilter _filter;
        readonly IJournal _journal;
        readonly IEditable _editable;
        static DBLibrary dB = new DBLibrary();
        private ILibraryItem m_SelectedItemn;
        public event PropertyChangedEventHandler PropertyChanged;
        public ILibraryItem SelectedItem
        {
            get
            {
                return m_SelectedItemn;
            }
            set
            {
                m_SelectedItemn = value;
                ToStringItemMethod(m_SelectedItemn);
                OnPropertyChanged("m_SelectedItemn");
            }
        }
        private ICollectionView collectionView;
        public ICollectionView CollectionView
        {
            get
            {
                return collectionView;
            }
            set
            {
                collectionView = value;
                OnPropertyChanged("CollectionView");
            }
        }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand EditItemCommand { get; set; }
        public int EditPrice { get; set; }
        public double EditDiscount { get; set; }
        public int EditStock { get; set; }
        public DisplayEditVM(IBook admin, IEditable editable, IFilter filter, IJournal journal)
        {
            _admin = admin;
            _filter = filter;
            _editable = editable;
            _journal = journal;

            //Filling the library with DB items.
            LoadDB();

            CollectionView = CollectionViewSource.GetDefaultView(CollectionManager.FilterCollection);
            _filter.RefreshEvent += RefreshFilteredCollection;
            _admin.RefreshEvent += RefreshFilteredCollection;
            _admin.AddEvent += AddBookToDB;
            _journal.RefreshEvent += RefreshFilteredCollection;
            EditItemCommand = new RelayCommand(EditItemMethod);
        }
        private static void LoadDB()
        {
            foreach (var journal in dB.Journals.ToList())
            {
                CollectionManager.FilterCollection.Add(journal);
            }
            foreach (var book in dB.Books.ToList())
            {
                CollectionManager.FilterCollection.Add(book);
            }
        }
        public static void AddBookToDB(Book bookFromUser)
        {
            try
            {
                var temp = bookFromUser.GetPublishedDate;
                dB.Books.Add(bookFromUser);
                dB.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void EditItemMethod()
        {
            if (m_SelectedItemn != null)
            {
                try
                {
                    EditItemInList(m_SelectedItemn, EditPrice, EditDiscount, EditStock);
                    CollectionView = CollectionViewSource.GetDefaultView(CollectionManager.FilterCollection);
                    CollectionView.Refresh();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Unable to convert", "Alert");
                }
                catch (Exception)
                {
                    MessageBox.Show("Cant edit nullable properties!", "Alert");
                    return;
                }
            }
            else
            {
                MessageBox.Show("No item was selected!", "Alert");
            }
        }
        private void EditItemInList(ILibraryItem item, int price, double discount, int stock)
        {
            var bookToEdit = new Book { GetPrice = price, GetDiscount = discount, GetStock = stock };
            _editable.EditItem(item, bookToEdit);
        }
        private void ToStringItemMethod(ILibraryItem item)
        {
            try
            {
                if (item != null)
                {
                    string details = $"ISBN:{item.GetISBN} \nName:{item.GetName} \nAuthor:{item.GetAuthor} \nPrice:{item.GetPrice} \nPublished In:{item.GetPublishedDate:d} \nCategory:{item.GetCategory} \n Discount:{item.GetDiscount} \nIn Stock:{item.GetStock}";
                    MessageBox.Show(details, "Details:");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No item was selected!", "Notice!");
                return;
            }

        }
        private void RefreshFilteredCollection()
        {
            CollectionView = CollectionViewSource.GetDefaultView(CollectionManager.FilterCollection);
            CollectionView.Refresh();
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
