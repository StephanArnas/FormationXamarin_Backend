using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Infrastructure.Repositories
{
   public class UserRepository : ReposityBase<UserEntity>, IUserRepository
    {
        #region ----- CONSTRUCTOR -----------------------------------------------------

        public UserRepository(ApplicationDbContext context) : base(context) { }

        #endregion

        #region ----- INTERFACE METHODS -----------------------------------------------

        public async Task<UserEntity> GetAsync(string email, bool loadEntities = false)
        {
            if (loadEntities)
            {
                return await Context.Users
                    .Include(x => x.Operations)
                    .FirstOrDefaultAsync(x => x.Email.Equals(email));
            }
            else return await Context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<UserEntity> GetWithEntityAsync(int userId)
        {
            return await Context.Users
                .Include(x => x.Operations)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        #endregion
    }
}
