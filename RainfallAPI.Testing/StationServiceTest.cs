using RainfallApi.Domain.Entities;
using RainfallApi.Infrastructure.Repositories;
using Moq;

namespace RainfallApi.Testing
{
    public class StationServiceTest
    {
        [Fact]
        public async Task GetRainfallStationsAsync_Returns_50_RainfallStations()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var stationService = new StationRepository(mockHttpClient.Object);

            // Act
            var rainfallStations = await stationService.GetStationsAsync();

            // Assert
            Assert.NotNull(rainfallStations);
            Assert.Equal(50, rainfallStations.Count());
        }
    }
}