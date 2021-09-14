using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Entities;

namespace takipApp.Business.Abstract
{
    public interface IContactService
    {
        List<ContactTable> GetAll();

        ContactTable GetById(int id);

        ContactTable Create(ContactTable contactTable);

        ContactTable Update(ContactTable contactTable);

        void DeleteHotel(int id);
    }
}
