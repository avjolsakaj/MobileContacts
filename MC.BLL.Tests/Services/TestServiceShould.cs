using MC.BLL.Services;
using MC.DAL.Repositories;
using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.Repositories;
using MC.IDAL.UOW;
using Moq;
using Xunit;

namespace MC.BLL.Tests.Services
{
    public class TestServiceShould
    {
        private readonly Mock<IUnitOfWork> _uofMock;
        private readonly Mock<ITestRepository> _repoMock;
        private readonly Mock<ITestMapper> _mapperMock;
        private readonly ITestService _sut;
        private readonly TestDTO _testDTO;
        private readonly Test _test;

        public TestServiceShould()
        {
            _testDTO = new TestDTO
            {
                Id = 1
            };

            _test = new Test
            {
                Id = 1,
                Desc = "Test"
            };

            _uofMock = new Mock<IUnitOfWork>();
            _ = _uofMock.SetupAllProperties();
            _mapperMock = new Mock<ITestMapper>();
            _ = _mapperMock.SetupAllProperties();

            _uofMock.SetupGet(uof => uof.TestRepository)
                .Returns(It.IsAny<TestRepository>())
                .Verifiable("Can't verify Test Repository");

            _uofMock.Setup(uof => uof.TestRepository.GetFirst())
                .ReturnsAsync(_test)
                .Verifiable("Can't verify Get");

            _mapperMock.Setup(x => x.Convert(_test))
                .Returns(_testDTO)
                .Verifiable("Can't verify Test Converter");

            _repoMock = new Mock<ITestRepository>();
            _repoMock.Setup(r => r.GetFirst()).ReturnsAsync(_test);

            _sut = new TestService(_repoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async void GetReturnOneTestDTO()
        {
            // Arrange

            // Act
            var result = await _sut.Get().ConfigureAwait(false);

            // Assert
            //_uofMock.Verify(x => x.TestRepository.GetFirst(), Times.Once);
            //_uofMock.Verify(x => x.TestRepository, Times.Once);

            _repoMock.Verify(x => x.GetFirst(), Times.Once);
            _mapperMock.Verify(x => x.Convert(_test), Times.Once);
            _uofMock.VerifyNoOtherCalls();

            Assert.NotNull(result);
            Assert.Equal(_testDTO.Id, result.Id);
            _ = Assert.IsType<TestDTO>(result);
        }
    }
}
