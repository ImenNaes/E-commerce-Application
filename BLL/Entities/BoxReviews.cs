using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class BoxReviews
    {
        [Key]
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Summary { get; set; }
        public string Review { get; set; }
        public int rating { get; set; }
        public Guid Userid { get; set; }
        public bool Favourite { get; set; }

        public Guid? ProdID { get; set; }
        [ForeignKey("ProdID")]
        public virtual Product Product { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public BoxReviews()
        {
            ID = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
