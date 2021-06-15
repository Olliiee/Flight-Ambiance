using System.ComponentModel.DataAnnotations;

namespace Org.Strausshome.FS.CrewSoundsNG.Models
{
    public enum SettingType
    {
        Device = 1,
        Music = 2,
        Ambiance = 3,
        DoorEffect = 4,
        Seatbelt = 5,
        ShowText = 6,
        SeatbeltsOff = 7,
        SeatbeltsOn = 8,
        Lowpass = 9,
        Highpass = 10,
        GainLow = 11,
        GainHigh = 12,
        Announcement = 13
    }

    public class Settings
    {
        [Key]
        public int Id { get; set; }

        public SettingType Setting { get; set; }
        public string Value { get; set; }
    }
}