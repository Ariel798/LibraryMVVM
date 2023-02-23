using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOPFFinalProject;
using OOPFFinalProject.Models;
using Service;
using Service.Services;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTestDataService
    {
        BookService bookService = new BookService();
        JournalService journalService = new JournalService();
        EditService editService = new EditService();
        Book errorBook = new Book {GetISBN= -3, GetName = "s", Price = 5, Discount = 1, GetCategory = Category.Horror, GetAuthor = "d", GetPublishedDate = DateTime.Now.ToString("MMMM d, yyyy"), GetPublisher = "s", Stock = 2, NumberInSeries = 1 };
        Journal errorJournal = new Journal { GetISBN = -3, GetName = "s", Price = 5, Discount = -3, GetCategory = Category.Horror, GetAuthor = "d", GetPublishedDate = DateTime.Now.ToString("MMMM d, yyyy"), GetPublisher = "s", Stock = 2, NumberOfLegion = 3 };
        public void AddforTest()
        {
            bookService.SupplyBook(errorBook);
            journalService.SupplyJournal(errorJournal);
        }

        [TestMethod]
        public void TestMethodAddBook()
        {
            Assert.ThrowsException<InvalidOperationException>(AddExeption);
            void AddExeption() => bookService.SupplyBook(errorBook);
        }
        [TestMethod]
        public void TestMethodAddJournal()
        {
            Assert.ThrowsException<InvalidOperationException>(AddExeption);
            void AddExeption() => journalService.SupplyJournal(errorJournal);
        }
        [TestMethod]    
        public void TestMethodEdit()
        {
            Assert.IsFalse(editService.EditItem(errorJournal, new Book { Price = 2,Stock = 1, Discount = 1}));
        }
    }
}
