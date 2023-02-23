using IOCLibrary.DataBase;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace IOCLibrary.Context
{
    public class LibraryContext
    {
        public LibraryContext(IJournal iJournal, IBook iBook)
        {
            LoadDB();
            iBook.AddEvent += AddBookToDB;
            iJournal.AddEvent += AddJournal;
        }
        void LoadDB()
        {
            foreach (var journal in GetJournals())
            {
                CollectionManager.FilterCollection.Add(journal);
            }
            foreach (var book in GetBooks())
            {
                CollectionManager.FilterCollection.Add(book);
            }
        }
        public void AddBookToDB(Book bookFromUser)
        {
            using (var context = new DBLibrary())
            {
                try
                {
                    context.Books.Add(bookFromUser);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public List<Book> GetBooks()
        {
            using (var context = new DBLibrary())
            {
                return context.Books.ToList();
            }
        }
        public List<Journal> GetJournals()
        {
            using (var context = new DBLibrary())
            {
                return context.Journals.ToList();
            }
        }
        public void AddJournal(Journal journalFromUser)
        {
            using (var context = new DBLibrary())
            {
                try
                {
                    context.Journals.Add(journalFromUser);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;

                }
            }
        }
    }
}
