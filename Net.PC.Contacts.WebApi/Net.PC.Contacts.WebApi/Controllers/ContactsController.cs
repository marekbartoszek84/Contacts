using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.PC.Contacts.Repository.Entities;
using Net.PC.Contacts.Repository.Repository;
using Net.PC.Contacts.WebApi.Models;

namespace Net.PC.Contacts.WebApi.Controllers
{
    [Route("api/contacts")]
    [Authorize]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _contactRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var result = _contactRepository.GetDetails(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(ContactRequest contactRequest)
        {
            var contact = _mapper.Map<Contact>(contactRequest);

            if (contact != null)
            {
                _contactRepository.Add(contact);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _contactRepository.Delete(id);

            return Ok();
        }
    }
}
