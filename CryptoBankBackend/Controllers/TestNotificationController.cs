using CryptoBankBackend.Core.Interfaces;
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
    public class TestNotificationController : ControllerBase
    {
        #region ----- ATTRIBUTES ------------------------------------------------------

        private readonly INotificationService _notificationService = null;

        #endregion

        #region ----- CONSTRUCTOR -----------------------------------------------------

        public TestNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion

        #region ----- WEBSERVICE METHODS ----------------------------------------------

        [HttpGet, AllowAnonymous]
        [Route("api/v1/[controller]/[action]/{userId}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public IActionResult SendNotification(int userId)
        {
            _notificationService.SendNotification(userId, "test notification title", "test notification content");
            return Ok();
        }

        #endregion
    }
}
