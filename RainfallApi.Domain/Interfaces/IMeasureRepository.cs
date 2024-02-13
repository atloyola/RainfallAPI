using RainfallApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RainfallApi.Domain.Interfaces
{
    public interface IMeasureRepository
    {        
        Task<IEnumerable<Measure>> GetMeasuresByStationReferenceAsync(string stationReference);
    }
    
}
