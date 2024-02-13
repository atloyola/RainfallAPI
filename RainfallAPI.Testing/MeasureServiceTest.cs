using RainfallApi.Domain.Entities;
using RainfallApi.Infrastructure.Repositories;
using Moq;

namespace RainfallApi.Testing
{
    public class MeasureServiceTest
    {
        [Fact]
    public async Task GetMeasuresForStationAsync_Returns_3_Measures()
        {
            // Arrange
            var mockHttpClient = new Mock<HttpClient>();            
            var measureService = new MeasureRepository(mockHttpClient.Object);

            // Act
            var measures = await measureService.GetMeasuresByStationReferenceAsync("3680");

            // Assert
            Assert.NotNull(measures);
            Assert.Equal(3, measures.Count());
        }
    }
}