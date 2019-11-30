using AutoMapper;
using CryptoBankBackend.Common.Exceptions;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Web.Models.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CryptoBankBackend.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class CommonController : ControllerBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IOperationService _operationService = null;
        protected readonly IMapper _mapper = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public CommonController(IOperationService operationService, IMapper mapper)
        {
            _operationService = operationService;
            _mapper = mapper;
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        [HttpGet, AllowAnonymous]
        [Route("api/v1/[controller]/[action]/{userId}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Common(int userId)
        {
            var totalOfTransaction = await _operationService.GetCountAllAsync(userId);
            return Ok(totalOfTransaction);
        }

        #endregion
    }
}
