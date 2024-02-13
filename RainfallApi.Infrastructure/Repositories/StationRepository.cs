using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RainfallApi.Domain.Entities;
using RainfallApi.Domain.Interfaces;

namespace RainfallApi.Infrastructure.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly HttpClient _httpClient;

        public StationRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Station>> GetStationsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://environment.data.gov.uk/flood-monitoring/id/stations?parameter=rainfall&_limit=50");                

                var content = await response.Content.ReadAsStringAsync();                

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var stationResponse = JsonSerializer.Deserialize<StationResponse>(content, options);

                return stationResponse.Items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching stations: {ex.Message}");
                return new List<Station>();
            }
        }

        public async Task<Station> GetStationByIdAsync(string stationId)
        {
            var response = await _httpClient.GetAsync($"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(content))
                {
                    return JsonSerializer.Deserialize<Station>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }

            return new Station();
        }

    }
}

public class StationResponse
{
    public Station[] Items { get; set; }
}
