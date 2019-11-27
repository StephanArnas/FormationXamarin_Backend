using CryptoBankBackend.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserEntity> 
    {
        Task<UserEntity> GetAsync(string email, bool loadEntities = false);

        Task<UserEntity> GetWithEntityAsync(int userId);
    }
}
