using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOPFFinalProject;
using OOPFFinalProject.Interfaces;
using OOPFFinalProject.Models;
using OOPFFinalProject.Objects;
using Service;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IOCLibrary
{
    //The VM of the filter user control.
    public class FilterVM : ViewModelBase , INotifyPropertyChanged
    {
        #region Members
        private bool filterISBNFlag;
        private bool filterDiscountFlag;
        private bool filterPriceFlag;
        private bool filterStockFlag;
        private bool horrorFlag;
        private bool fictionFlag;
        private bool romanceFlag;
        private bool kitchenFlag;
        public bool FilterISBNFlag { get { return filterISBNFlag; } set { filterISBNFlag = value; } }
        public bool FilterDiscountFlag { get { return filterDiscountFlag; } set { filterDiscountFlag = value; } }
        public bool FilterPriceFlag { get { return filterPriceFlag; } set { filterPriceFlag = value;} }
        public bool FilterStockFlag { get { return filterStockFlag; } set { filterStockFlag = value;} }
        public bool HorrorFlag { get { return horrorFlag; } set { horrorFlag = value; } }
        public bool FictionFlag { get { return fictionFlag; } set { fictionFlag = value; } }
        public bool RomanceFlag { get { return romanceFlag; } set { romanceFlag = value; } }
        public bool KitchenFlag { get { return kitchenFlag; } set { kitchenFlag = value; } }
        readonly IBook _iBook;
        readonly IFilter _filter;
        readonly ICalculator calculator;
        public static ICollectionView CollectionView { get; set; }
        public RelayCommand FilterCommand { get; set; }
        public RelayCommand EverythingCommand { get; set; }
        public int GetFilterISBN { get; set; }
        public string GetFilterName { get; set; }
        public double GetFilterDiscount { get; set; }
        public int GetFilterPrice { get; set; }
        public int GetFilterStock { get; set; }
        #endregion
        public FilterVM(IBook admin, IFilter filter,ICalculator calculator)
        {
            _iBook = admin;
            _filter = filter;
            this.calculator= calculator;
            FilterCommand = new RelayCommand(FilterCommandMethod);
            EverythingCommand = new RelayCommand(EverythingCommandMethod);
        }
        private void EverythingCommandMethod()
        {
            _filter.ReturnFullCollection();
        }
        private void FilterCommandMethod()
        {
            Category categories = calculator.CalculateCategory(horrorFlag,fictionFlag,romanceFlag,kitchenFlag);
            var filterObj = new FilterItem { GetISBN = GetFilterISBN, GetName = GetFilterName, Discount = GetFilterDiscount, Price = GetFilterPrice, Stock = GetFilterStock, GetCategory = categories, filterISBNFlag = filterISBNFlag, filterDiscountFlag = filterDiscountFlag, filterPriceFlag = filterPriceFlag, filterStockFlag = filterStockFlag };
            _filter.ReturnFilteredCollection(filterObj);
        }
    }
}
