using CryptoBankBackend.Common.Exceptions;
using CryptoBankBackend.Core.Interfaces;
using CryptoBankBackend.Core.Interfaces.Repositories;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Core.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoBankBackend.Core.Services
{
    public class OperationService : ServiceBase, IOperationService
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IOperationRepository _operationRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly INotificationService _notificationService = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public OperationService(IConfiguration configuration
            , IOperationRepository operationRepository
            , IUserRepository userRepository
            , INotificationService notificationService) : base(configuration)
        {
            _operationRepository = operationRepository;
            _userRepository = userRepository;
            _notificationService = notificationService;
        }

        #endregion

        #region ----- INTERFACE METHODS -----------------------------------------------

        public async Task<IEnumerable<OperationEntity>> GetAllAsync(int userId, int? page)
        {
            var userDb = await _userRepository.GetAsync(userId);
            if (userDb == null) throw new NotFoundException("User not found.");

            IEnumerable<OperationEntity> operationsDb;
            if (page.HasValue)
            {
                operationsDb = await _operationRepository.GetAllAsync(userId, page);
            }
            else
            {
                operationsDb = await _operationRepository.GetAllAsync();
            }
            return operationsDb;
        }

        public async Task<OperationEntity> GetAsync(int userId, int operationId)
        {
            var userDb = await _userRepository.GetAsync(userId);
            if (userDb == null) throw new NotFoundException("User not found.");

            var operationDb = await _operationRepository.GetAsync(operationId);
            if (operationDb == null) throw new NotFoundException("Operation not found.");

            return operationDb;
        }

        public async Task<int> GetCountAllAsync(int userId)
        {
            return await _operationRepository.CountAsync(x => x.UserId == userId);
        }

        public async Task CreateAsync(int userId, OperationEntity operation)
        {
            if (operation == null) throw new BadRequestException("Operation payload could not be null.");
            if (operation.Amount <= 0) throw new BadRequestException("You have to send a positive amount of money.");
            if (string.IsNullOrEmpty(operation.Name)) throw new BadRequestException("You have to define a name for the operation.");

            var userDb = await _userRepository.GetAsync(userId);
            if (userDb == null) throw new NotFoundException("User not found.");

            var recipientDb = await _userRepository.GetAsync(operation.RecipientEmail);
            if (recipientDb == null) throw new NotFoundException("Recipient not found.");

            var createdDate = DateTimeOffset.UtcNow;

            recipientDb.Credits += operation.Amount;
            var recipientOperation = new OperationEntity();
            recipientOperation.Name = operation.Name;
            recipientOperation.TransactionNumber = Guid.NewGuid().ToString();
            recipientOperation.RecipientEmail = userDb.Email;
            recipientOperation.Amount = operation.Amount;
            recipientOperation.UserId = recipientDb.Id;
            recipientOperation.CreatedDate = createdDate;

            operation.TransactionNumber = Guid.NewGuid().ToString();
            operation.Amount = operation.Amount * -1;
            operation.UserId = userId;
            operation.CreatedDate = createdDate;
            userDb.Credits += operation.Amount;

            await _operationRepository.AddAsync(operation);
            await _operationRepository.AddAsync(recipientOperation);

            _notificationService.SendNotification(userDb.Id, "", "Vous avez envoyé " + recipientOperation.Amount + " à " + recipientDb.Email + " envoyé !");
            _notificationService.SendNotification(recipientDb.Id, "", "Vous avez reçu " + recipientOperation.Amount + " de la part de " + userDb.Email + "!");
        }

        public async Task UpdateAsync(int userId, OperationEntity operation)
        {
            if (operation == null) throw new BadRequestException("Operation payload could not be null.");

            var userDb = await _userRepository.GetAsync(userId);
            if (userDb == null) throw new NotFoundException("User not found.");

            var operationDb = await _operationRepository.GetAsync(operation.Id);
            if (operationDb == null) throw new NotFoundException("Operation not found.");

            operationDb.Name = operation.Name;
            await _operationRepository.UpdateAsync(operation);
        }

        #endregion
    }
}
