using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Business.Abstract;
using takipApp.DataAccess.Abstract;
using takipApp.DataAccess.Concrete;
using takipApp.Entities;

namespace takipApp.Business.Concreate
{
    public class SeferManager : ISeferService
    {

        private IContanctRepository _seferRepository;

        public SeferManager()
        {
            _seferRepository = new SeferRepository();
        }
        public BusTable Create(BusTable busTable)
        {
            return _seferRepository.Create(busTable);
        }

        public void DeleteHotel(int id)
        {
            _seferRepository.Delete(id);
        }

        public List<BusTable> GetAll()
        {
            return _seferRepository.GetAll();
        }

        public BusTable GetById(int id)
        {
            return _seferRepository.GetById(id);
            //if (id > 0)
            //{
                
            //}
            //throw new Exception("ID alanı 1'den küçük olamaz. ");
        }

        public BusTable Updata(BusTable busTable)
        {
            return _seferRepository.Updata(busTable);
        }
    }
}
