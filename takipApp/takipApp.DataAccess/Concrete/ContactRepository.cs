using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using takipApp.DataAccess.Abstract;
using takipApp.Entities;

namespace takipApp.DataAccess.Concrete
{
    public class ContactRepository : IContactRepository
    {
        public ContactTable Create(ContactTable contactTable)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                takipAppDbContext.ContactTable.Add(contactTable);
                takipAppDbContext.SaveChanges();
                return contactTable;

            }
        }

        public void Delete(int id)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                var Deleted = GetById(id);
                takipAppDbContext.ContactTable.Remove(Deleted);
                takipAppDbContext.SaveChanges();
            }
        }

        public List<ContactTable> GetAll()
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                return takipAppDbContext.ContactTable.ToList();

            }
        }

        public ContactTable GetById(int id)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                return takipAppDbContext.ContactTable.Find(id);
            }
        }

        public ContactTable Update(ContactTable contactTable)
        {
            using (var takipAppDbContext = new takipAppDbContext())
            {
                takipAppDbContext.ContactTable.Update(contactTable);
                takipAppDbContext.SaveChanges();
                return contactTable;
            }
        }
    }
}
