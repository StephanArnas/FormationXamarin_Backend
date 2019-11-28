using AutoMapper;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Controllers
{
    [ApiController]
    public class OperationController : ControllerBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IOperationService _operationService = null;
        protected readonly IMapper _mapper = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public OperationController(IOperationService operationService, IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        [HttpGet]
        [Route("api/v1/[controller]/[action]/{userId}/{page}")]
        [ProducesResponseType(typeof(IEnumerable<OperationApi>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(int userId, int page)
        {
            var operationsDb = await _operationService.GetAllAsync(userId, page);
            return Ok(_mapper.Map<IEnumerable<OperationApi>>(operationsDb));
        }

        [HttpGet]
        [Route("api/v1/[controller]/[action]/{userId}/{operationId}")]
        [ProducesResponseType(typeof(OperationApi), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int userId, int operationId)
        {
            var operationDb = await _operationService.GetAsync(userId, operationId);
            return Ok(_mapper.Map<OperationApi>(operationDb));
        }

        [HttpPost]
        [Route("api/v1/[controller]/[action]/{userId}")]
        [ProducesResponseType(typeof(UserApi), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendMoney(int userId, [FromBody]OperationApi operation)
        {
            await _operationService.CreateAsync(userId, _mapper.Map<OperationEntity>(operation));
            return Ok();
        }

        [HttpPut]
        [Route("api/v1/[controller]/[action]/{userId}")]
        [ProducesResponseType(typeof(UserApi), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOperationName(int userId, [FromBody]OperationApi operation)
        {
            await _operationService.UpdateAsync(userId, _mapper.Map<OperationEntity>(operation));
            return Ok();
        }

        #endregion
    }
}
