using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BLL.Entities
{
    public class ProductType
    {        
        [Key]
        public Guid ID { get; set; }       
        public bool IsDeleted { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }

        public Guid? CategID { get; set; }
        [ForeignKey("CategID")]
        public virtual ProductCategorie ProductCategory { get; set; }
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<Product> Products { get; set; }
        [Display(Name = "Upload File")]
        public byte[] Icon { get; set; }
        public ProductType()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
