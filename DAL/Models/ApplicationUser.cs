using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime? CreationDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FullName { get; set; }
        public bool Disable { get; set; }

        //[AsyncStateMachine(typeof(<GenerateUserIdentityAsync> d__32))]
        //[DebuggerStepThrough]
        //public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager);
        public ApplicationUser()
        {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
