using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IOCLibrary.Context;
using IOCLibrary.DataBase;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        #region Properties&Fields
        readonly IBook _iBook;
        readonly IFilter _filter;
        readonly IJournal _journal;
        readonly IEditable _editable;
        private ILibraryItem m_SelectedItemn;
        public event PropertyChangedEventHandler PropertyChanged;
        public static LibraryContext context { get; set; }
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
        #endregion
        public DisplayEditVM(IBook iBook, IEditable editable, IFilter filter, IJournal journal, LibraryContext libraryContext)
        {
            _iBook = iBook;
            _filter = filter;
            _editable = editable;
            _journal = journal;
            context = libraryContext;

            CollectionView = CollectionViewSource.GetDefaultView(CollectionManager.FilterCollection);
            _filter.RefreshEvent += RefreshFilteredCollection;
            _iBook.RefreshEvent += RefreshFilteredCollection;
            _journal.RefreshEvent += RefreshFilteredCollection;
            EditItemCommand = new RelayCommand(EditItemMethod);
        }
        private void EditItemMethod()
        {
            m_SelectedItemn.GetType();
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
            var bookToEdit = new Book { Price = price, Discount = discount, Stock = stock };
            _editable.EditItem(item, bookToEdit);
        }
        private void ToStringItemMethod(ILibraryItem item)
        {
            try
            {
                if (item != null)
                {
                    string details = $"ISBN:{item.GetISBN} \nName:{item.GetName} \nAuthor:{item.GetAuthor} \nPrice:{item.Price} \nPublished In:{item.GetPublishedDate:d} \nCategory:{item.GetCategory} \n Discount:{item.Discount} \nIn Stock:{item.Stock}";
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
