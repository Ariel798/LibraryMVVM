using System;
using System.ComponentModel.DataAnnotations;

namespace OOPFFinalProject.Models
{
    public class Journal : ILibraryItem
    {
        [Key]
        public int GetISBN { get; set; }
        public int NumberOfLegion { get; set; }
        public string GetName { get; set; }
        public string GetAuthor { get; set; }

        public string GetPublisher { get; set; }

        public string GetPublishedDate { get; set; }

        public Category GetCategory { get; set; }
        public int GetPrice { get; set; }

        public double GetDiscount { get; set; }
        public int GetStock { get; set; }
    }
}
