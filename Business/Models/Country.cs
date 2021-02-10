using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid ID { get; set; }
        [Required]
        public string NameEn { get; set; }
        [Required]

        public string NameAr { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
