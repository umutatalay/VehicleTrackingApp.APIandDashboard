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
using Firebase.Database;
using Firebase.Database.Query;
using takipApp.DataAccess;

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
            busTable.Day = model.Day;
            _seferService.Create(busTable);

            return RedirectToAction("Seferler");
        }

        [Route("SeferGuncelle/{id?}")]
        public IActionResult SeferGuncelle(int id)
        {
            var gelensefer = _seferService.GetById(id);

            SeferGuncelleModel model = new SeferGuncelleModel
            {
                TypeOfBus = gelensefer.TypeOfBus,
                firstLocation = gelensefer.firstLocation,
                DropOffLocation = gelensefer.DropOffLocation,
                Hour = gelensefer.Hour,
                Day = gelensefer.Day,

            };

            return View(model);
        }
        [HttpPost]
        [Route("SeferGuncelle/{id?}")]
        public IActionResult SeferGuncelle(SeferGuncelleModel model)
        {
            var guncellenecekSefer = _seferService.GetById(model.Id);
            guncellenecekSefer.firstLocation = model.firstLocation;
            guncellenecekSefer.DropOffLocation = model.DropOffLocation;
            guncellenecekSefer.Hour = model.Hour;
            guncellenecekSefer.TypeOfBus = model.TypeOfBus;
            guncellenecekSefer.Day = model.Day;
            _seferService.Updata(guncellenecekSefer);
            return RedirectToAction("Seferler");
        }

        
        [Route("SeferSil/{id?}")]
        public void SeferSil(int id)
        {
            _seferService.DeleteHotel(id);
        }


        [Route("SeferGuncelleSil")]
        public IActionResult SeferGuncelleSil()
        {
            return View(_seferService.GetAll());
        }


        //public async Task<ActionResult> Iletisim()
        //{
        //    //Simulate test user data and login timestamp


        //    //Save non identifying data to Firebase
        //  //  var currentUserLogin = new LoginData() { TimestampUtc = currentLoginTime };
        //    var firebaseClient = new FirebaseClient("https://vehicletrackingflutter-default-rtdb.firebaseio.com/");


        //    //Retrieve data from Firebase
        //    var dbLogins = await firebaseClient
        //      .Child("Users")
        //      .OnceAsync<>();

        //    var timestampList = new List<DateTime>();

        //    //Convert JSON data to original datatype
        //    foreach (var login in dbLogins)
        //    {
        //        timestampList.Add(Convert.ToDateTime(login.Object.TimestampUtc).ToLocalTime());
        //    }

        //    //Pass data to the view
        //    ViewBag.CurrentUser = userId;
        //    ViewBag.Logins = timestampList.OrderByDescending(x => x);
        //    return View();
        //}

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string sifre)
        {


            using (var context = new takipAppDbContext())
            {
                foreach (var item in context.User)
                {



                    if (item.Eposta == email && item.Password == sifre)
                    {
                        return RedirectToAction("dashboardIndex");
                    }
                }
            }

            return View("seferekle");
        }

    }
}
