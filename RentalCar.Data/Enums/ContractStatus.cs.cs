using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Enums
{
    public enum ContractStatus
    {
        New,        // Mới lập (chờ giao xe) — chỉ trạng thái này mới được sửa / hủy
        Renting,    
        Returned,  
        Cancelled  
    }
}
