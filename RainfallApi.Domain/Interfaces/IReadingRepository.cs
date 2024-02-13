using RainfallApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RainfallApi.Domain.Interfaces
{    
    public interface IReadingRepository
    {        
        Task<IEnumerable<Reading>> GetReadingsByStationReferenceAsync(string stationReference, int count);        
    }
}
