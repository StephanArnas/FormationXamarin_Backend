using CryptoBankBackend.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Interfaces.Services
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationEntity>> GetAllAsync(int userId, int? page);
        Task<OperationEntity> GetAsync(int userId, int operationId);
        Task CreateAsync(int userId, OperationEntity operation);
        Task UpdateAsync(int userId, OperationEntity operation);
        Task<int> GetCountAllAsync(int userId);
    }
}
