using OOPFFinalProject.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace IOCLibrary.DataBase
{
    public partial class DBLibrary : DbContext
    {
        public DBLibrary()
            : base("name=DBLibrary")
        {
        }
        public virtual DbSet<Journal> Journals { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
