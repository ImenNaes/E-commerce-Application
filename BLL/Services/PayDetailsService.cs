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
    public class PayDetailsService: BaseService<PaymentDetails> , IPayDetailsService
    {
        private readonly IPaymentDetails _paydetailsrepository;
        public PayDetailsService(IPaymentDetails paydetailsrepository) : base(paydetailsrepository)
        {
            _paydetailsrepository = paydetailsrepository;
        }
    }
}
