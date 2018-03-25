using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobTrackerDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public abstract class BaseController : Controller
    {
        protected Facade facade;

        protected BaseController()
        {
            facade = new Facade();
        }
    }
}