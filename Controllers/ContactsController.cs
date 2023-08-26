using ContactsAPI.Models;
using ContactsAPI.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactsService _contactsService;

        public ContactsController(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetContact([FromRoute] Guid id)
        {
            var contact = _contactsService.GetContact(id);
            if(contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_contactsService.GetContacts());            
        }

        [HttpPost]
        public ActionResult<Contact> AddContact(Contact contact) 
        {
            if(_contactsService.AddContact(contact))
            {
                return contact;
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id:guid}")]
        public ActionResult<Contact> UpdateContact([FromRoute] Guid id ,Contact contact) 
        {
            if(_contactsService.UpdateContact(id, contact))
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public ActionResult DeleteContact([FromRoute] Guid id)
        {
            if(_contactsService.DeleteContact(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
