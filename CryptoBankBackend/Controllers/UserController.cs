using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using CryptoBankBackend.Common.Extensions;
using CryptoBankBackend.Core.Interfaces.Services;
using CryptoBankBackend.Core.Models.Entities;
using CryptoBankBackend.Web.Models.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptoBankBackend.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IUserService _userService = null;
        protected readonly IMapper _mapper = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        [HttpGet]
        [Route("api/v1/[controller]/[action]/{userId}")]
        [ProducesResponseType(typeof(UserApi), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int userId)
        {
            UserEntity userDb = await _userService.GetAsync(userId, true);
            return Ok(_mapper.Map<UserApi>(userDb));
        }

        #endregion
    }
}
