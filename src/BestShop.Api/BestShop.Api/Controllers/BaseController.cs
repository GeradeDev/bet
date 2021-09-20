using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BestShop.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        protected Guid GetUserId()
        {
            return Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        protected string GetUserEmail()
        {
            return this.User.FindFirstValue(ClaimTypes.Email);
        }
    }
}
