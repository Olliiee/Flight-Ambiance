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
    public class FlightStatusRepository
    {
        private readonly CsContext _csContext;
        private readonly ILogger<FlightStatusRepository> _logger;

        public FlightStatusRepository(ILogger<FlightStatusRepository> logger, CsContext csContext)
        {
            _logger = logger;
            _csContext = csContext;
        }

        public async Task<FlightStatusProfile> GetFlightStatusProfileAsync(string name)
        {
            var profile = await _csContext.FlightStatusProfiles
                .Include(c => c.FlightStatus)
                .Where(c => c.Name == name)
                .FirstOrDefaultAsync().ConfigureAwait(false);
            return profile;
        }

        public async Task<FlightStatusProfile> AddFlightStatusProfileAsync(FlightStatusProfile profile)
        {
            try
            {
                await _csContext.FlightStatusProfiles.AddAsync(profile).ConfigureAwait(false);
                await _csContext.SaveChangesAsync();

                return profile;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddFlightStatus(FlightStatus flightStatus)
        {
            try
            {
                await _csContext.FlightStatuses.AddAsync(flightStatus).ConfigureAwait(false);
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new flight status.");
                throw;
            }
        }

        public async Task<FlightStatus> GetFlightStatusAsync(int id)
        {
            var flightStatus = await _csContext.FlightStatuses.FindAsync(id).ConfigureAwait(false);
            return flightStatus;
        }

        public async Task<FlightStatus> GetFlightStatusByName(FlightStatusName statusName)
        {
            var status = await _csContext.FlightStatuses.Where(flightStatus => flightStatus.FlightStatusName == statusName).FirstOrDefaultAsync().ConfigureAwait(false);
            return status;
        }

        public async Task<List<string>> GetFlightStatusNamesBySeqAsync()
        {
            var names = await _csContext.FlightStatuses.OrderBy(c => c.Sequence).Select(c => c.Name).ToListAsync().ConfigureAwait(false);
            return names;
        }

        public async Task<List<FlightStatus>> GetFlightStatusAsync()
        {
            var status = await _csContext.FlightStatuses.OrderBy(c => c.Sequence).ToListAsync().ConfigureAwait(false);
            return status;
        }

        public async Task<FlightStatus> GetNextFlightStatusAsync(int index)
        {
            var status = await _csContext.FlightStatuses.Where(c => c.Sequence == (index + 1)).FirstOrDefaultAsync().ConfigureAwait(false);
            return status;
        }

        public async Task AddOwnFlightStatusAsync(FlightStatus flightStatus)
        {
            flightStatus.FlightStatusName = FlightStatusName.Own;
            try
            {
                await _csContext.AddAsync(flightStatus).ConfigureAwait(false);
                await _csContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding new own flight status.");
                throw;
            }
        }
    }
}