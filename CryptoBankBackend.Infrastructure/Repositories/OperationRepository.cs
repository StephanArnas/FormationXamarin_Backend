using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Infrastructure.Repositories
{
    public class OperationRepository : ReposityBase<OperationEntity>, IOperationRepository
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        #region CONST

        internal const int PAGE_SIZE_MEDIUM = 20;
        internal const int PAGE_SIZE_SMALL = 10;
        internal const int PAGE_SIZE_VERY_SMALL = 5;

        #endregion

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public OperationRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region ----- INTERFACE METHODS -----------------------------------------------

        public async Task<IEnumerable<OperationEntity>> GetAllAsync(int userId, int? page)
        {
            return await Context.Operations
                .OrderByDescending(x => x.CreatedDate)
                .Skip(page.HasValue ? (page.Value - 1) * PAGE_SIZE_SMALL : 0 * PAGE_SIZE_SMALL)
                .Take(PAGE_SIZE_SMALL)
                .Where(x => x.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        #endregion
    }
}
