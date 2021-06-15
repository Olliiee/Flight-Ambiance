using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public class FlightStatusProfile
    {
        [Key]
        public int ProfileId { get; set; }

        public string Name { get; set; }

        public List<FlightStatus> FlightStatus { get; set; }
    }
}