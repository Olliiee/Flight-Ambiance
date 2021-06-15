using Microsoft.Extensions.Logging;

using Org.Strausshome.FS.CrewSoundsNG.Data;
using Org.Strausshome.FS.CrewSoundsNG.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Org.Strausshome.FS.CrewSoundsNG.Repositories
{
    public class MediaFileRepository
    {
        private readonly CsContext _csContext;
        private readonly ILogger<MediaFileRepository> _logger;

        public MediaFileRepository(CsContext csContext, ILogger<MediaFileRepository> logger)
        {
            _csContext = csContext;
            _logger = logger;
        }

        public async Task<List<MediaFile>> AddRangeAsync(List<MediaFile> mediaFiles)
        {
            await _csContext.MediaFiles.AddRangeAsync(mediaFiles).ConfigureAwait(false);
            await _csContext.SaveChangesAsync();
            return mediaFiles;
        }

        public async Task<MediaFile> AddAsync(MediaFile mediaFile)
        {
            await _csContext.MediaFiles.AddAsync(mediaFile).ConfigureAwait(false);
            await _csContext.SaveChangesAsync();
            return mediaFile;
        }

        public async Task<MediaFile> GetFileAsync(int id)
        {
            return await _csContext.MediaFiles.FindAsync(id).ConfigureAwait(false);
        }
    }
}