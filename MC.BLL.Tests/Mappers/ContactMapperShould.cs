using MC.BLL.Mappers;
using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;
using Moq;
using Xunit;

namespace MC.BLL.Tests.Mappers
{
    public class PersonMapperShould
    {
        private readonly Mock<IContactMapper> _mapperMock;

        public PersonMapperShould()
        {
            _mapperMock = new Mock<IContactMapper>();
            _ = _mapperMock.SetupAllProperties();

            _mapperMock.Setup(x => x.Convert(new Contact()))
                .Returns((ContactDetailsDTO) null)
                .Verifiable("Can't verify Test Converter");
        }

        [Fact]
        public void ConvertToDTO()
        {
            // Arrange
            var sut = new PersonMapper(_mapperMock.Object);

            var dto = new PersonDetailsDTO
            {
                Id = 1
            };

            var model = new Person
            {
                Id = 1,
                FirstName = "First",
                LastName = "Last",
                MiddleName = "Middle"
            };

            // Act
            var result = sut.Convert(model);

            // Assert
            Assert.NotNull(result);
            _ = Assert.IsType<PersonDetailsDTO>(result);
            Assert.Equal(dto.Id, result.Id);
        }

        [Fact]
        public void ReturnNull()
        {
            // Arrange
            var sut = new PersonMapper(_mapperMock.Object);

            // Act
            var result = sut.Convert((Person) null);

            // Assert
            Assert.Null(result);
        }
    }
}
