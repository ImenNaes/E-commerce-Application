using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class ProductCategorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string FontAwesome { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }

        //public IEnumerable<ProductType> Producttypes { get; set; }
        //public Guid? ProductCategoriesImagesID { get; set; }
        //public virtual ICollection<ProductCategoriesImages> ProductCategoriesImages { get; set; }
    }
}
