using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public class ProfileItem
    {
        [Key]
        public int ProfileItemId { get; set; }

        public FlightStatus FlightStatus { get; set; }
        public List<MediaFile> MediaFile { get; set; }
        public int Sequence { get; set; }
    }
}