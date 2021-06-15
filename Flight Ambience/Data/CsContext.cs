using Microsoft.EntityFrameworkCore;

using Org.Strausshome.FS.CrewSoundsNG.Models;

using System.Configuration;

namespace Org.Strausshome.FS.CrewSoundsNG.Data
{
    public class CsContext : DbContext
    {
        public DbSet<Settings> Settings { get; set; }
        public DbSet<FlightStatus> FlightStatuses { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileItem> ProfileItems { get; set; }
        public DbSet<FlightStatusProfile> FlightStatusProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=FlightAmbiance.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite(ConfigurationManager.ConnectionStrings["CrewSounds"].ConnectionString);
    }
}