using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using takipApp.Business.Abstract;
using takipApp.Business.Concreate;
using takipApp.Entities;
using takipAppAPI.Dtos;

namespace takipAppAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class BusController : Controller
    {
        private ISeferService _seferService;

        public BusController()
        {
            _seferService = new SeferManager();
        }

        [HttpGet]
        [Route("Hepsi")]
        public List<BusTable> Get()
        {
            return _seferService.GetAll();
        }

        [HttpGet("{id}")]
        public BusTable Get(int id)
        {
            return _seferService.GetById(id);
        }

        [HttpPost]
        public BusTable Post([FromBody]BusTable busTable)
        {
            return _seferService.Create(busTable);
        }

        [HttpPut]
        public BusTable Put([FromBody] BusTable busTable)
        {
            return _seferService.Updata(busTable);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _seferService.DeleteHotel(id);
        }

        [Route("index")]
        public IActionResult dashboardIndex()
        {
          
            return View();
        }

        
        [Route("Seferler")]
        public IActionResult Seferler()
        {
            return View(_seferService.GetAll());
        }


        [Route("SeferEkle")]
        public IActionResult SeferEkle()
        {
            return View(new SeferEkleModel());
        }
        [HttpPost]
        [Route("SeferEkle")]
        public IActionResult SeferEkle(SeferEkleModel model)
        {
            BusTable busTable = new BusTable();
            busTable.TypeOfBus = model.TypeOfBus;
            busTable.DropOffLocation = model.DropOffLocation;
            busTable.firstLocation = model.firstLocation;
            busTable.Hour = model.Hour;
            _seferService.Create(busTable);
            
            return View();
        }
    }
}
