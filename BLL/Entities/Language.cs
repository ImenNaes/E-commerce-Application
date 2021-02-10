using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Language
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameEn { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameAr { get; set; }
        [DefaultValue(false)]
        [Required]
        public bool Rtl { get; set; }
        [DefaultValue(false)]
        [Required]
        public bool Default { get; set; }
        public byte[] Icon { get; set; }
        public virtual Profile Profile { get; set; }

        public Language()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
