using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Data;
using Org.Strausshome.FS.CrewSoundsNG.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Org.Strausshome.FS.CrewSoundsNG.Repositories
{
    public class ProfileRepository
    {
        #region Private Fields

        private readonly CsContext _csContext;
        private readonly ILogger<ProfileRepository> _logger;

        #endregion Private Fields

        #region Public Constructors

        public ProfileRepository(ILogger<ProfileRepository> logger, CsContext csContext)
        {
            _logger = logger;
            _csContext = csContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Profile> AddProfileAsync(Profile profile)
        {
            await _csContext.Profiles.AddAsync(profile).ConfigureAwait(false);
            await _csContext.SaveChangesAsync().ConfigureAwait(false);

            return profile;
        }

        public async Task<ProfileItem> AddProfileItemAsync(ProfileItem item)
        {
            await _csContext.ProfileItems.AddAsync(item).ConfigureAwait(false);
            await _csContext.SaveChangesAsync().ConfigureAwait(false);

            return item;
        }

        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _csContext.Profiles.ToListAsync();
        }

        public async Task<MediaFile> GetMediaDetails(int mediaId)
        {
            return await _csContext.MediaFiles.FindAsync(mediaId).ConfigureAwait(false);
        }

        public async Task<List<MediaFile>> GetMediaFilesByItemNameAsync(string profileName, int itemId)
        {
            var profile = await GetProfileByNameAsync(profileName).ConfigureAwait(false);

            return profile.ProfileItems.Where(c => c.ProfileItemId == itemId).Select(c => c.MediaFile).FirstOrDefault();
        }

        public async Task<Profile> GetProfileByNameAsync(string name)
        {
            var profile = await _csContext.Profiles.Where(profile => profile.Name == name)
                .Include(profile => profile.ProfileItems)
                    .ThenInclude(item => item.FlightStatus)
                .Include(profile => profile.ProfileItems)
                    .ThenInclude(item => item.MediaFile)
                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<Profile> GetProfileByNameForExportAsync(string name)
        {
            var profile = await _csContext.Profiles.Where(profile => profile.Name == name)
                .Include(profile => profile.ProfileItems)
                    .ThenInclude(item => item.FlightStatus)
                .Include(profile => profile.ProfileItems)
                    .ThenInclude(item => item.MediaFile)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return profile;
        }

        public async Task<ProfileItem> GetProfileItemByIdAsync(int id)
        {
            return await _csContext.ProfileItems
                .Include(c => c.FlightStatus)
                .Include(c => c.MediaFile)
                .Where(c => c.ProfileItemId == id)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<bool> RemoveItemAsync(int itemId)
        {
            try
            {
                var item = await _csContext.ProfileItems.FindAsync(itemId).ConfigureAwait(false);
                _csContext.ProfileItems.Remove(item);
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveMediaFileAsync(int mediaId)
        {
            var mediaFile = await _csContext.MediaFiles.FindAsync(mediaId).ConfigureAwait(false);
            if (mediaFile != null)
            {
                try
                {
                    _csContext.Remove(mediaFile);
                    await _csContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> UpdateMediaType(int mediaId, MediaType type)
        {
            var mediaFile = await _csContext.MediaFiles.FindAsync(mediaId).ConfigureAwait(false);
            if (mediaFile != null)
            {
                try
                {
                    mediaFile.Type = type;
                    await _csContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> UpdateProfileAsync(Profile profile)
        {
            var oldProfile = await _csContext.Profiles.FindAsync(profile.ProfileId).ConfigureAwait(false);
            if (oldProfile != null)
            {
                try
                {
                    oldProfile.Name = profile.Name;
                    oldProfile.ProfileItems = oldProfile.ProfileItems;
                    await _csContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool> UpdateProfileItemAsync(ProfileItem profileItem)
        {
            var oldItem = await _csContext.ProfileItems.FindAsync(profileItem.ProfileItemId).ConfigureAwait(false);
            if (oldItem != null)
            {
                try
                {
                    oldItem.FlightStatus = profileItem.FlightStatus;
                    oldItem.MediaFile = profileItem.MediaFile;
                    oldItem.Sequence = profileItem.Sequence;
                    await _csContext.SaveChangesAsync().ConfigureAwait(false);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        #endregion Public Methods

        #region Internal Methods

        internal async Task<ProfileItem> GetNextItem(ProfileItem item, int nextSeq)
        {
            return await _csContext.ProfileItems.Where(c => c.ProfileItemId == item.ProfileItemId && c.Sequence == nextSeq).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        #endregion Internal Methods
    }
}