using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public enum ProductStatus
    {
            Confirmed = 0,
            New = 1,
            Sold = 2,
            Disable = 3,
            Hold = 4,
            Updated = 5,
            Deleted = 6,
            NotAvailable = 7,
            Rejected = 8
    }
}
