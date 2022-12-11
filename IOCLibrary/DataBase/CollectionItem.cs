namespace IOCLibrary.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CollectionItem")]
    public partial class CollectionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ISBN { get; set; }

        [Column("_Name")]
        [Required]
        [StringLength(25)]
        public string C_Name { get; set; }

        [Required]
        [StringLength(25)]
        public string AuthorName { get; set; }

        [StringLength(25)]
        public string Publisher { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Published { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

        [Required]
        [StringLength(50)]
        public string Stock { get; set; }

        public int? CopyNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeOfItem { get; set; }
    }
}
