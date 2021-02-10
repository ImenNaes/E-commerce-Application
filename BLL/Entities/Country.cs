using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entities
{
    public class Country
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]

        public string NameAr { get; set; }

        public ICollection<City> Cities { get; set; }
        //public virtual Profile Profile { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Country()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
