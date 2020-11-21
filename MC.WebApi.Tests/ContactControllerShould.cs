using MC.DTO;
using MC.IBLL.IServices;
using MC.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MC.IP.Tests
{
    public class ContactControllerShould
    {
        private readonly Mock<IContactService> _serviceMock;
        private readonly ContactController _sut;

        public ContactControllerShould()
        {
            var testDTO = new List<PersonDetailsDTO>
            {
                new PersonDetailsDTO
                {
                    Id = 1,
                    FirstName = "Avjol",
                     LastName = "Sakaj"
                }
            };

            _serviceMock = new Mock<IContactService>();
            _serviceMock.Setup(service => service.GetPersons("Avjol", "Id", true))
                .ReturnsAsync(testDTO)
                .Verifiable("Can't mock Test Service");

            _ = _serviceMock.SetupAllProperties();

            _sut = new ContactController(_serviceMock.Object);
        }

        [Fact]
        public async void GetListPersons()
        {
            // Arrange
            const int expected = 1;

            // Act
            var result = await _sut.GetPersons("Avjol", "Id", true).ConfigureAwait(false);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var testDTO = Assert.IsAssignableFrom<List<PersonDetailsDTO>>(ok.Value);

            _serviceMock.Verify(x => x.GetPersons("Avjol", "Id", true), Times.Once);

            Assert.NotNull(testDTO);
            Assert.Contains(testDTO, x => x.Id == expected);
        }
    }
}
