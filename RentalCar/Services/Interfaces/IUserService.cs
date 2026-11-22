using RentalCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();

    }
}
