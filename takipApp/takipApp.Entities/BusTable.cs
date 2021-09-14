using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace takipApp.Entities
{
    public class BusTable 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TypeOfBus { get; set; }
        public string firstLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string Hour { get; set; }
        public string Day { get; set; }
    }
}
