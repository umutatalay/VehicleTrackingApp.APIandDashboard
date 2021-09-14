using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using takipApp.Entities;

namespace takipApp.DataAccess.Abstract
{
   public interface IContanctRepository
    {
        List<BusTable> GetAll();

        BusTable GetById(int id);

        BusTable Create(BusTable busTable);

        BusTable Updata(BusTable busTable);

        void Delete(int id);
    }
}
