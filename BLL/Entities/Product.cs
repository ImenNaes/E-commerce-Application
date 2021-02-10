using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }   
        public bool IsDeleted { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string DescriptionEn { get; set; }
        [Required]
        public string DescriptionAr { get; set; }
        [Required]
        public decimal FromPrice { get; set; }
        //For Discount 
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }


        [Required]
        public DateTime ExpiryDate { get; set; }
        //public Guid? CitiesID { get; set; }
       
        //public bool PreOrder { get; set; }
        [Required]
        public string Code { get; set; }      
        //public Guid? ProductSmallImagesID { get; set; }
       
        public ProductStatus productstatus { get; set; }
       
        public Image MainImage { get; set; }

       
        public Guid? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual ProductType ProductType { get; set; }
      
        public Guid? CategID { get; set; }
        [ForeignKey("CategID")]
        public virtual ProductCategorie ProductCategory { get; set; }
        public ICollection<ProductViews> ProductViews { get; set; }
        public ICollection<BoxReviews> BoxReviews { get; set; }

        public Guid? Sizeid { get; set; }
        [ForeignKey("Sizeid")]
        public virtual Size Sizes { get; set; }
        //public virtual Profile Profile { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public Product()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        //public Product()
        //{
        //   // this.TypeID = Guid.Empty; 
        //}
    }
}
