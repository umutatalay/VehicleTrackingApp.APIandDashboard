using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace takipApp.Entities
{
    public class ContactTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMailAddress { get; set; }
        public string PhoneNumber { get; set; } 
        public string Message { get; set; }
    }
}
