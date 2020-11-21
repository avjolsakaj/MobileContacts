using MC.DTO;
using MC.IBLL.IServices;
using MC.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MC.IP.Tests
{
    public class TestControllerShould
    {
        private readonly Mock<ITestService> _serviceMock;
        private readonly TestController _sut;

        public TestControllerShould()
        {
            var testDTO = new TestDTO
            {
                Id = 1
            };

            _serviceMock = new Mock<ITestService>();
            _serviceMock.Setup(service => service.Get())
                .ReturnsAsync(testDTO)
                .Verifiable("Can't mock Test Service");

            _ = _serviceMock.SetupAllProperties();

            _sut = new TestController(_serviceMock.Object);
        }

        [Fact]
        public async void GetFirstTest()
        {
            // Arrange
            const int expected = 1;

            // Act
            var result = await _sut.GetFirst().ConfigureAwait(false);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var testDTO = Assert.IsAssignableFrom<TestDTO>(ok.Value);

            _serviceMock.Verify(x => x.Get(), Times.Once);

            Assert.NotNull(testDTO);
            Assert.Equal(expected, testDTO.Id);
        }
    }
}
