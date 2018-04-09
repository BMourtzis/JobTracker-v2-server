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
    public abstract class BaseController : Controller
    {
        protected readonly Facade facade;

        protected BaseController(Facade context)
        {
            facade = context;
        }
    }
}