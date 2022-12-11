

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using Service;
using Service.API;
using Service.Services;

namespace IOCLibrary.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<BookService>();
            SimpleIoc.Default.Register<EditService>();
            SimpleIoc.Default.Register<DataFilterService>();
            SimpleIoc.Default.Register<JournalService>();
            SimpleIoc.Default.Register<IBook>(() => SimpleIoc.Default.GetInstance<BookService>());
            SimpleIoc.Default.Register<INotifyBook>(() => SimpleIoc.Default.GetInstance<BookService>());
            SimpleIoc.Default.Register<IEditable>(() => SimpleIoc.Default.GetInstance<EditService>());
            SimpleIoc.Default.Register<IFilter>(() => SimpleIoc.Default.GetInstance<DataFilterService>());
            SimpleIoc.Default.Register<IJournal>(() => SimpleIoc.Default.GetInstance<JournalService>());
            SimpleIoc.Default.Register<INotifyJournal>(() => SimpleIoc.Default.GetInstance<JournalService>());
            SimpleIoc.Default.Register<DisplayEditVM>();
            SimpleIoc.Default.Register<FilterVM>();
            SimpleIoc.Default.Register<BookInsertVM>();
            SimpleIoc.Default.Register<JournalInsertMVM>();
        }

        public DisplayEditVM DisplayEditVM => ServiceLocator.Current.GetInstance<DisplayEditVM>();
        public FilterVM FilterVM => ServiceLocator.Current.GetInstance<FilterVM>();
        public BookInsertVM BookInsertVM => ServiceLocator.Current.GetInstance<BookInsertVM>();
        public JournalInsertMVM JournalInsertMVM => ServiceLocator.Current.GetInstance<JournalInsertMVM>();

    }
}