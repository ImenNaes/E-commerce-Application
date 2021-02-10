using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int SuggestedCount { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public decimal? FromPrice { get; set; }
        [Required]
        public decimal? Discount { get; set; }
        [Required]
        public DateTime? ExpiryDate { get; set; }
        //public Guid? CitiesID { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        //public bool PreOrder { get; set; }
        [Required]
        public string Code { get; set; }
        //public Guid? ProductSmallImagesID { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
       
        public Guid? CategID { get; set; }
        [ForeignKey("CategID")]
        public virtual ProductCategorie ProductCategorie{ get; set; }
    }
}
