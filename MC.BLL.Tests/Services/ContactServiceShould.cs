using MC.BLL.Services;
using MC.DAL.Repositories;
using MC.DTO;
using MC.ENTITY.Models.DBO;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.Repositories;
using MC.IDAL.UOW;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MC.BLL.Tests.Services
{
    public class ContactServiceShould
    {
        private readonly Mock<IUnitOfWork> _uofMock;

        private readonly Mock<IPersonMapper> _mapperPersonMock;
        private readonly Mock<IContactMapper> _mapperContactMock;
        private readonly Mock<IContactTypeMapper> _mapperContactTypeMock;

        private readonly IContactService _sut;

        private readonly PersonDetailsDTO _personDetailsDTO;
        private readonly Person _person;
        private readonly List<Person> _persons;

        public ContactServiceShould()
        {
            _personDetailsDTO = new PersonDetailsDTO { Id = 1 };

            _person = new Person { Id = 1, FirstName = "Avjol", LastName = "Sakaj" };
            _persons = new List<Person> { _person };

            _uofMock = new Mock<IUnitOfWork>();

            _uofMock.Setup(x => x.PersonRepository.GetPersons(_person.FirstName, "ID", true))
                .ReturnsAsync(_persons);

            _mapperPersonMock = new Mock<IPersonMapper>();
            _mapperContactMock = new Mock<IContactMapper>();
            _mapperContactTypeMock = new Mock<IContactTypeMapper>();

            _mapperPersonMock.Setup(x => x.Convert(_person))
                .Returns(_personDetailsDTO);

            _sut = new ContactService(_uofMock.Object, _mapperPersonMock.Object, _mapperContactMock.Object, _mapperContactTypeMock.Object);
        }

        [Fact]
        public async void GetReturnOneTestDTO()
        {
            // Arrange

            // Act
            var result = await _sut.GetPersons(_person.FirstName, "Id", true).ConfigureAwait(false);

            // Assert
            _uofMock.Verify(x => x.PersonRepository, Times.Once);
            _uofMock.Verify(x => x.PersonRepository.GetPersons(_person.FirstName, "ID", true), Times.Once);

            _mapperPersonMock.Verify(x => x.Convert(_person), Times.AtLeastOnce);
            _uofMock.VerifyNoOtherCalls();

            Assert.NotNull(result);
            Assert.Contains(result, x => x.Id == _personDetailsDTO.Id);
            _ = Assert.IsType<List<PersonDetailsDTO>>(result);
        }
    }
}
