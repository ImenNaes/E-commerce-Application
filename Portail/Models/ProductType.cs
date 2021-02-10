using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portail.Models
{
    public class ProductType
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

        public Guid? CategID { get; set; }
        [ForeignKey("CategID")]
        public virtual ProductCategorie ProductCategorie { get; set; }

    }
}
