using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact()
            {
                Mail = createContactDto.Mail,
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Phone = createContactDto.Phone
            };
            _contactService.Tadd(contact);
            return Ok("Contact Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values= _contactService.TGetByID(id);
            _contactService.Tdelete(values);
            return Ok("Contact Silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact()
            {
                Mail = updateContactDto.Mail,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone
            };
            _contactService.Tupdate(contact);
            return Ok("Contact Güncellendi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }
    }
}
