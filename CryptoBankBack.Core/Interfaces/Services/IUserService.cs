using CryptoBankBackend.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<int> LoginAsync(string userEmail, string userPassword);

        Task<UserEntity> GetAsync(int userId, bool withCollections = false);
        Task<UserEntity> GetAsync(string userEmail);
    }
}
