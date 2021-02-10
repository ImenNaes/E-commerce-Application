using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace BLL.Entities
{
    public class ProductCategorie
    {
        [Key]
        public Guid ID { get; set; } 
        public bool IsDeleted { get; set; }
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        public string FontAwesome { get; set; }
        //public ICollection<Product> Products { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
        public ICollection<Product> Products { get; set; }

        [Display(Name = "Upload File")]
        public byte[] Icon { get; set; }

        //public IEnumerable<ProductType> Producttypes { get; set; }
        //public Guid? ProductCategoriesImagesID { get; set; }
        //public virtual ICollection<ProductCategoriesImages> ProductCategoriesImages { get; set; }      
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ProductCategorie()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
