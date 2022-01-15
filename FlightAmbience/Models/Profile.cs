using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        public string Name { get; set; }

        public List<ProfileItem> ProfileItems { get; set; }
    }
}