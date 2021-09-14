using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace takipAppAPI.Dtos
{
    public class SeferGuncelleModel
    {
        public int Id { get; set; }
        public string TypeOfBus { get; set; }
        public string firstLocation { get; set; }
        public string DropOffLocation { get; set; }
        public string Hour { get; set; }
        public string Day { get; set; }
    }
}
