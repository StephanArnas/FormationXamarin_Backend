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
    public class AuthController : ControllerBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly IUserService _userService = null;
        protected readonly IMapper _mapper = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public AuthController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        /// <summary>
        /// Log in into OneBoard with a login / password.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Login
        ///     {
        ///        "email": "stephan.arnas@gmail.com",
        ///        "password": "Aze123"
        ///     }
        ///     
        /// </remarks>
        /// <param name="login">Credential information.</param>
        [HttpPost, AllowAnonymous]
        [Route("api/v1/[controller]/[action]")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ResponseErrorApi), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ResponseErrorApi), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Login([FromBody]LoginApi login)
        {
            if (string.IsNullOrEmpty(login.Email)) throw new BadRequestException($"{nameof(LoginApi.Email)} can't be null or empty.");
            if (string.IsNullOrEmpty(login.Password)) throw new BadRequestException($"{nameof(LoginApi.Password)} can't be null or empty.");

            var userId = await _userService.LoginAsync(login.Email, login.Password);
            return Ok(userId);
        }

        #endregion
    }
}
