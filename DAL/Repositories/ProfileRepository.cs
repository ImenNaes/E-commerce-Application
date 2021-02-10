using BLL.Entities;
using BLL.Interfaces;
using BLL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public void AddProfileImage(Guid id, Image img)
        {
            _ctx.Profile.SingleOrDefault(p => p.Id.Equals(id)).Images.Add(img);
        }

        public Profile GetByEmail(string email)
        {
            return _ctx.Profile.ToList().Find(p => p.Email.ToLower() == email.ToLower());
        }

        public IEnumerable<Profile> GetByName(string termo)
        {
            return _ctx.Profile.ToList().Where(p => p.FirstName.ToLower().Contains(termo.ToLower()) ||
                                                p.Email.ToLower().Contains(termo.ToLower())).OrderBy(p => p.FirstName).Take(25);
        }
        public bool Activationcode(string id)
        {
            bool statusAccount = false;
            var userAccount = _ctx.Profile.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

                if (userAccount != null)
                {
                    userAccount.IsActive = true;
                    _ctx.SaveChanges();
                    statusAccount = true;
                }
                else
                {
                     statusAccount = true;
                }
            return statusAccount;
        }
    }
}
