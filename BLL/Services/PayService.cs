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
    public class PayService: BaseService<Payment> , IPaymentService
    {
        private readonly IPaymentRepository _paymentrepository;
        public PayService(IPaymentRepository paymentrepository) : base(paymentrepository)
        {
            _paymentrepository = paymentrepository;
        }
    }
}
