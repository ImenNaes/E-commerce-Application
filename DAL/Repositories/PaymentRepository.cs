using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces.Repositories;

namespace DAL.Repositories
{
   public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
    }
}
