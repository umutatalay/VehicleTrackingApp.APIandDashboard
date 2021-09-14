using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using takipApp.Business.Abstract;
using takipApp.Business.Concreate;
using takipApp.Entities;

namespace takipAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private IContactService _contactService;
        public ContactController()
        {

            _contactService = new ContactManager();
        }
        [HttpGet]
        [Route("Hepsi")]
        public List<ContactTable> IletisimGet()
        {
            return _contactService.GetAll();
        }
        [Route("post")]
        [HttpPost]
        public ContactTable Post([FromBody] ContactTable contactTable)
        {
            return _contactService.Create(contactTable);
        }

        [Route("iletisim")]
        public IActionResult AllContact()
        {
            return View(_contactService.GetAll());
        }

        [Route("mesajsil/{id?}")]
        public void mesajsil(int id)
        {
            _contactService.DeleteHotel(id);
        }

        [Route("mesajdetay/{id?}")]
        public IActionResult mesajdetay(int id)
        {
            dynamic Data = _contactService.GetById(id);
            return View(Data);
        }
    }
}