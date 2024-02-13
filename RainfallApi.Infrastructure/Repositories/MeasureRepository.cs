using System.Net.Http;
using System.Text.Json;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;

namespace RainfallApi.Infrastructure.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        private readonly HttpClient _httpClient;

        public MeasureRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }      

        public async Task<IEnumerable<Measure>> GetMeasuresByStationReferenceAsync(string stationReference)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationReference}/measures");

                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var measureResponse = JsonSerializer.Deserialize<MeasureResponse>(content, options);

                return measureResponse.Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching measures: {ex.Message}");
                return new List<Measure>();
            }
        }
    }
}

public class MeasureResponse
{
    public Measure[]? Items { get; set; }
}