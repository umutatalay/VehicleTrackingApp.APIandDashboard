using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using takipApp.DataAccess.Abstract;
using takipApp.Entities;

namespace takipApp.DataAccess.Concrete
{
    public class SeferRepository : ISeferRepository
    {
        public BusTable Create(BusTable busTable)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                takipAppDbContext.BusTable.Add(busTable);
                takipAppDbContext.SaveChanges();
                return busTable;

            }
        }

        public void Delete(int id)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                var Deleted = GetById(id);
                takipAppDbContext.BusTable.Remove(Deleted);
                takipAppDbContext.SaveChanges();
            }
        }

        public List<BusTable> GetAll()
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                return takipAppDbContext.BusTable.ToList();
                
            }
        }

        public BusTable GetById(int id)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                return takipAppDbContext.BusTable.Find(id);
            }
        }

        public BusTable Updata(BusTable busTable)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                takipAppDbContext.BusTable.Update(busTable);
                takipAppDbContext.SaveChanges();
                return busTable;
            }
        }
    }
}
