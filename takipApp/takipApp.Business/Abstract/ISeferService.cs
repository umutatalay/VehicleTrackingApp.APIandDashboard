using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Entities;

namespace takipApp.Business.Abstract
{
    public interface ISeferService
    {
        List<BusTable> GetAll();

        BusTable GetById(int id);

        BusTable Create(BusTable busTable);

        BusTable Updata(BusTable busTable);

        void DeleteHotel(int id);
    }
}
