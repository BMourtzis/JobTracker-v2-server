using System;
using JobTracker_API.Models.Client;
using JobTrackerDomain;
using JobTrackerDomain.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker_API.Controllers
{
    [Route("client")]
    [EnableCors("AllowAllOrigins")]
    public class ClientController : BaseController
    {
        public ClientController(Facade context) : base(context) { }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var client = facade.GetClient(id);
                return Ok(client);
            }
            catch (BusinessRuleException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var clients = facade.GetClients();
                return Ok(clients);
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] CreateVM model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var client = facade.CreateClient(model.firstname, model.lastname, model.businessName, model.invoicePrefix, model.address, model.email, model.primaryPhone);
                    return Ok(client);
                }
                catch (BusinessRuleException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.Keys);
            }
        }

        [HttpPut]
        [Route("{id}/update")]
        public IActionResult Update(Guid id, [FromBody] UpdateVM model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var client = facade.UpdateClient(id , model.firstname, model.lastname, model.businessName, model.address, model.email, model.primaryPhone);
                    return Ok(client);
                }
                catch(BusinessRuleException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.Keys);
            }
        }

        [HttpPut]
        [Route("{id}/enable")]
        public IActionResult Enable(Guid id)
        {
            try
            {
                var client = facade.EnableClient(id);
                return Ok(client);
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}/disable")]
        public IActionResult Disable(Guid id)
        {
            try
            {
                var client = facade.DisableClient(id);
                return Ok(client);
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}