using System;
using JobTracker_API.Models;
using JobTrackerDomain;
using JobTrackerDomain.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JobTracker_API.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Client")]
    [EnableCors("AllowAllOrigins")]
    public class ContactController : BaseController
    {
        public ContactController(Facade context) : base(context) { }

        [HttpPost]
        [Route("{id}/contacts/add")]
        public IActionResult AddContact(Guid id, [FromBody] AddContactVM model)
        {
            try
            {
                var contacts = facade.AddContact(id, model.Contacts);
                return Ok(contacts);
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}/contacts/{contactId}/update")]
        public IActionResult UpdateContact(Guid id, Guid contactId, [FromBody] UpdateContactVM model)
        {
            try
            {
                var contact = facade.UpdateContact(id, contactId, model.Name, model.ContactValue);
                return Ok(contact);
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}/contacts/{contactId}/delete")]
        public IActionResult RemoveContact(Guid id, Guid contactId)
        {
            try
            {
                facade.RemoveContact(id, contactId);
                return Ok();
            }
            catch (BusinessRuleException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}