using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Entities;

namespace takipApp.DataAccess.Abstract
{
    public interface IContactRepository
    {
        List<ContactTable> GetAll();

        ContactTable GetById(int id);

        ContactTable Create(ContactTable contactTable);

        ContactTable Update(ContactTable contactTable);

        void Delete(int id);
    }
}
