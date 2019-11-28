using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Common.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Services
{
    public class UserService : ServiceBase, IUserService
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IUserRepository _userRepository = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public UserService(IConfiguration configuration, IUserRepository userRepository) : base(configuration)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region ----- INTERFACE METHODS -----------------------------------------------

        public async Task<UserEntity> GetAsync(int userId, bool withCollections = false)
        {
            UserEntity userDb;
            if (withCollections)
            {
                userDb = await _userRepository.GetWithEntityAsync(userId);
            }
            else
            {
                userDb = await _userRepository.GetAsync(userId);
            }

            if (userDb == null) throw new NotFoundException("User not found.");
            return userDb;
        }

        public async Task<UserEntity> GetAsync(string userEmail)
        {
            var userDb = await _userRepository.GetAsync(userEmail);
            if (userDb == null) throw new NotFoundException("User not found.");
            return userDb;
        }

        public async Task<int> LoginAsync(string userEmail, string userPassword)
        {
            var userDb = await _userRepository.GetAsync(userEmail);
            if (userDb == null)
            {
                throw new NotFoundException("Wrong email.");
            }

            if (userDb.Password != userPassword)
            {
                throw new UnauthorizedException("Wrong password.");
            }

            return userDb.Id;
        }

        #endregion
    }
}
