using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.API;
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
        readonly IBook _admin;
        readonly IFilter _filter;
        public static ICollectionView CollectionView { get; set; }
        public RelayCommand FilterCommand { get; set; }
        public RelayCommand EverythingCommand { get; set; }
        public int GetFilterISBN { get; set; }
        public string GetFilterName { get; set; }
        public double GetFilterDiscount { get; set; }
        public int GetFilterPrice { get; set; }
        public int GetFilterStock { get; set; }
        public FilterVM(IBook admin, IFilter filter)
        {
            _admin = admin;
            _filter = filter;
            FilterCommand = new RelayCommand(FilterCommandMethod);
            EverythingCommand = new RelayCommand(EverythingCommandMethod);
        }
        private void EverythingCommandMethod()
        {
            _filter.ReturnFullCollection();
        }
        private void FilterCommandMethod()
        {
            Category categories = CalculateCategory();
            _filter.ReturnFilteredCollection(GetFilterISBN ,GetFilterName, GetFilterDiscount, GetFilterPrice, GetFilterStock,categories,filterISBNFlag, filterDiscountFlag, filterPriceFlag, filterStockFlag);
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
    }
}
