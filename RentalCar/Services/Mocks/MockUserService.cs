using RentalCar.Models;
using RentalCar.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Services.Mocks
{
    public class MockUserService 
    {
        public MockUserService() 
        {
            // Code chức năng ở đây
        }

        public Task<List<User>> GetAllAsync()
        {
            // Code chức năng ở đây
            return Task.FromResult(new List<User>());
        }

        public Task AddAsync(User user)
        {
            // Code chức năng ở đây
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User user)
        {
            // Code chức năng ở đây
            return Task.CompletedTask;
        }

    }
}
