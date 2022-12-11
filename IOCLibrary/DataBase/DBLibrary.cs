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

        public virtual DbSet<CollectionItem> CollectionItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.C_Name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.AuthorName)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.Publisher)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.Category)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.Stock)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CollectionItem>()
                .Property(e => e.TypeOfItem)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
