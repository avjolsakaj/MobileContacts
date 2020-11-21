using MC.BLL.Mappers;
using MC.DTO;
using MC.ENTITY.Models.DBO;
using Xunit;

namespace MC.BLL.Tests.Mappers
{
    public class TestMapperShould
    {
        [Fact]
        public void ConvertToDTO()
        {
            // Arrange
            var sut = new TestMapper();

            var dto = new TestDTO
            {
                Id = 1
            };

            var model = new Test
            {
                Id = 1,
                Desc = "Test"
            };

            // Act
            var result = sut.Convert(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TestDTO>(result);
            Assert.Equal(dto.Id, result.Id);
        }

        [Fact]
        public void ReturnNull()
        {
            // Arrange
            var sut = new TestMapper();

            // Act
            var result = sut.Convert(null);

            // Assert
            Assert.Null(result);
        }
    }
}
