using CryptoBankBackend.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Interfaces.Repositories
{
    public interface IOperationRepository : IRepositoryBase<OperationEntity>
    {
        Task<IEnumerable<OperationEntity>> GetAllAsync(int userId, int? page);
    }
}
