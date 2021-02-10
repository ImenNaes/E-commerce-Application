using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Repositories
{
    public interface IProfileRepository: IBaseRepository<Profile>
    {
        IEnumerable<Profile> GetByName(String termo);
        Profile GetByEmail(String email);
        void AddProfileImage(Guid id, Image img);
    }
}
