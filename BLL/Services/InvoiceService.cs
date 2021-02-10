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
    public class InvoiceService : BaseService<Invoice> , IInvoiceService
    {
        private readonly IInvoiceRepository _invoicerepository;
        public InvoiceService(IInvoiceRepository invoicerepository) : base(invoicerepository)
        {
            _invoicerepository = invoicerepository;
        }
    }
}
