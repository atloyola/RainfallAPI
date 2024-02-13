using System.Text.Json;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;

namespace RainfallApi.Infrastructure.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly HttpClient _httpClient;

        public ReadingRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Reading>> GetReadingsByStationReferenceAsync(string stationReference, int count = 10)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationReference}/readings?_sorted&_limit={count}");                

                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var readingResponse = JsonSerializer.Deserialize<ReadingResponse>(content, options);

                return readingResponse.Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching readings: {ex.Message}");
                return new List<Reading>();
            }            
        }        
       
    }
    
}

public class ReadingResponse
{
    public Reading[] Items { get; set; }
}