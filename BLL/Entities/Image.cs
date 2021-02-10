using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Image
    {
        [Key]
        public Guid Id { get; set; }
       
        public ICollection<ProductSmallImages> ProductSmallImages { get; set; }
        public Guid? ProductID { get; set; }
        
        public byte[] ImageContent { get; set; }
        [Column("Description")]
        public String Description { get; set; }
        [Column("CreationDate")]
        public DateTime? CreationDate { get; set; }
        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }    
        //public virtual Gallery Gallery { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public Image()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
