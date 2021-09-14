using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using takipApp.Entities;


namespace takipApp.DataAccess
{
    public class takipAppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Change your mssql server ne ame 
            
            optionsBuilder.UseSqlServer("Server=DESKTOP-IT4752E; Database=TakipAppVeriTabani;Integrated Security=True;");
        }
        public DbSet<BusTable> BusTable { get; set; }
        public DbSet<ContactTable> ContactTable { get; set; }
        public DbSet<User> User { get; set; }
    }
}
