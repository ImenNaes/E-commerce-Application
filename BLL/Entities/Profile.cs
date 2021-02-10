using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class Profile
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        [Column("FirstName")]
        public String FirstName { get; set; }
        [Column("LastName")]
        public String LastName { get; set; }
        [Column("Email")]
        public String Email { get; set; }
        [Column("Birthday")]

        public DateTime? Birthday { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Column("Photo")]
        public String PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public Guid ActivationCode { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        //public virtual Country Country { get; set; }
        //public virtual City City { get; set; }
        //public virtual Adress Addres { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public Profile() 
        {
            Id = Guid.NewGuid();
        }
    }
}
