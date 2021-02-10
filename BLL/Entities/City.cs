using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class City
    {

        [Key]
        public Guid ID { get; set; }     
        [Required]
        public string NameEn { get; set; }
        [Required]
        public string NameAr { get; set; }
        public Guid? CountryID { get; set; }
        [ForeignKey("CountryID")]
        public virtual Country Country { get; set; }
        //public virtual Profile Profile { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public City()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
