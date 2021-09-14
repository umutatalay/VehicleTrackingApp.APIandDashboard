using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Business.Abstract;
using takipApp.DataAccess.Abstract;
using takipApp.DataAccess.Concrete;
using takipApp.Entities;

namespace takipApp.Business.Concreate
{
    public class ContactManager:IContactService
    {
        private IContactRepository _contactRepository;

        public ContactManager()
        {
            _contactRepository = new ContactRepository();
        }

        public ContactTable Create(ContactTable contactTable)
        {
            return _contactRepository.Create(contactTable);
        }

        public void DeleteHotel(int id)
        {
            _contactRepository.Delete(id);
        }

        public List<ContactTable> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public ContactTable GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public ContactTable Update(ContactTable contactTable)
        {
            throw new NotImplementedException();
        }
    }
}
