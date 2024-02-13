using RainfallApi.Domain.Entities;
using RainfallApi.Infrastructure.Repositories;
using Moq;

namespace RainfallApi.Testing
{
    public class ReadingServiceTest
    {
        [Fact]
        public async Task GetReadingsByStationAsync_Returns_10_Readings()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();
            var readingService = new ReadingRepository(mockHttpClient.Object);

            // Act
            var readings = await readingService.GetReadingsByStationReferenceAsync("3680");

            // Assert
            Assert.NotNull(readings);
            Assert.Equal(10, readings.Count());
        }
    }
}