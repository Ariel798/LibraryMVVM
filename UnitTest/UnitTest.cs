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
        LibraryItem item = new Book(2, "d", "s", "ss", DateTime.Now, Category.Romance, 23, 2, 2, 3);
        public void AddforTest()
        {
            bookService.SupplyBook(2, "d", "s", "ss", DateTime.Now, Category.Romance, 23, 2, 2, 3);
            journalService.SupplyJournal(3, "d", "s", "ss", DateTime.Now, Category.Romance, 23, 2, 2, 3);
        }

        [TestMethod]
        public void TestMethodAddBook()
        {
            Assert.ThrowsException<InvalidOperationException>(AddExeption);
            void AddExeption() => bookService.SupplyBook(-3, "sdasd", "asda", "as", DateTime.Now, Category.Romance, 3, 4, 2, 1);
        }
        [TestMethod]
        public void TestMethodAddJournal()
        {
            Assert.ThrowsException<InvalidOperationException>(AddExeption);
            void AddExeption() => journalService.SupplyJournal(-3, "sdasd", "asda", "as", DateTime.Now, Category.Romance, 3, 4, 2, 1);
        }
        [TestMethod]    
        public void TestMethodEdit()
        {
            Assert.IsFalse(editService.EditItem(item, 4, 2, 1));
        }
    }
}
