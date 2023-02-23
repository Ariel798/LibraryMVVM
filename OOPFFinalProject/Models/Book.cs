using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFFinalProject.Models
{
    public class Book : ILibraryItem
    {
        [Key]
        public int GetISBN { get; set; }
        public string GetName { get; set; }
        public string GetAuthor { get; set; }

        public string GetPublisher { get; set; }

        public string GetPublishedDate { get; set; }

        public Category GetCategory { get; set; }

        public double Discount { get; set; }
        public int Stock { get; set; }
        public int NumberInSeries { get; set; }
        public int Price { get; set; }
    }
}
