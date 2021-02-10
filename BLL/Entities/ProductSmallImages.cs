using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class ProductSmallImages
    {
        [Key]
        public Guid ID { get; set; }
        [Column("Photo")]
        public string PhotoUrl { get; set; }
        public byte[] SmallImageContent { get; set; }
        //public Guid ProductsID { get; set; }
        //public virtual Product Product { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? MainImageID { get; set; }
        [ForeignKey("MainImageID")]
        public virtual Image MainImage { get; set; }
        public ProductSmallImages()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
