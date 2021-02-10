using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Repositories;
using BLL.Interfaces.Services;

namespace BLL.Services
{
    public class ContactService: BaseService<ContactSMS> , IContactService
    {
        private readonly IContactsRepository _contactrepository;
        public ContactService(IContactsRepository contactrepository) : base(contactrepository)
        {
            _contactrepository = contactrepository;
        }
    }
}
