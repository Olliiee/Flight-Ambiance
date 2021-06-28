using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public enum MediaType
    {
        Music,
        Announcement,
        Ambiance
    }

    public class MediaFile
    {
        [Key]
        public int MediaFileId { get; set; }

        public string Path { get; set; }
        public string Name { get; set; }
        public MediaType Type { get; set; }
    }
}