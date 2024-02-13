using RainfallApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RainfallApi.Domain.Interfaces
{    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetStationsAsync();
        Task<Station> GetStationByIdAsync(string stationId);        
    }
}
