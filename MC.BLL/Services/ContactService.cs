using MC.DTO;
using MC.IBLL.IMappers;
using MC.IBLL.IServices;
using MC.IDAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public readonly IPersonMapper _personMapper;
        private readonly IContactMapper _contactMapper;
        private readonly IContactTypeMapper _contactTypeMapper;

        public ContactService(IUnitOfWork unitOfWork, IPersonMapper personMapper, IContactMapper contactMapper, IContactTypeMapper contactTypeMapper)
        {
            _unitOfWork = unitOfWork;

            _personMapper = personMapper;
            _contactMapper = contactMapper;
            _contactTypeMapper = contactTypeMapper;
        }

        public async Task<List<PersonDetailsDTO?>> GetPersons(string? filterValue, string orderBy, bool orderAsc)
        {
            var person = await _unitOfWork.PersonRepository.GetPersons(filterValue, orderBy.ToUpper(), orderAsc).ConfigureAwait(false);

            return person.ConvertAll(_personMapper.Convert);
        }

        public async Task<PersonDetailsDTO?> CreatePerson(CreatePersonDTO request)
        {
            bool exist = await _unitOfWork.PersonRepository.GetAsync(request.FirstName, request.LastName).ConfigureAwait(false);

            if (exist)
            {
                throw new ArgumentException("User already exist!");
            }

            var createPerson = _personMapper.Convert(request);

            if (createPerson is null)
            {
                throw new ArgumentException("Request is not in right format!");
            }

            var createdPerson = await _unitOfWork.PersonRepository.AddAsync(createPerson).ConfigureAwait(false);

            _ = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            var result = await _unitOfWork.PersonRepository.GetAsync(createdPerson.Id).ConfigureAwait(false);

            return _personMapper.Convert(result);
        }

        public async Task<PersonDetailsDTO?> UpdatePerson(EditPersonDTO request)
        {
            var editPerson = _personMapper.Convert(request);

            if (editPerson is null)
            {
                throw new ArgumentException("Request is not in right format!");
            }

            var updatedPerson = await _unitOfWork.PersonRepository.UpdateAsync(editPerson).ConfigureAwait(false);

            _ = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            var result = await _unitOfWork.PersonRepository.GetAsync(updatedPerson.Id).ConfigureAwait(false);

            return _personMapper.Convert(result);
        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = await _unitOfWork.PersonRepository.GetAsync(id).ConfigureAwait(false);

            if (person is null)
            {
                throw new ArgumentException("Person not found!");
            }

            _ = await _unitOfWork.PersonRepository.DeleteAsync(id).ConfigureAwait(false);

            foreach (var item in person.Contact)
            {
                _ = await _unitOfWork.ContactRepository.DeleteAsync(item.Id).ConfigureAwait(false);
            }

            int result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<PersonDetailsDTO?> CreateContact(List<CreateContactDTO> request, int personId)
        {
            var person = await _unitOfWork.PersonRepository.GetAsync(personId).ConfigureAwait(false);

            if (person is null)
            {
                throw new ArgumentException("Person not found!");
            }

            foreach (var item in request)
            {
                var contact = _contactMapper.Convert(item, personId);

                _ = await _unitOfWork.ContactRepository.AddAsync(contact).ConfigureAwait(false);
            }

            _ = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            var result = await _unitOfWork.PersonRepository.GetAsync(personId).ConfigureAwait(false);

            return _personMapper.Convert(result);
        }

        public async Task<PersonDetailsDTO?> UpdateContact(List<EditContactDTO> request, int personId)
        {
            foreach (var item in request.ConvertAll(x => _contactMapper.Convert(x, personId)))
            {
                if (item is null)
                {
                    continue;
                }

                var contact = await _unitOfWork.ContactRepository.GetAsync(item.Id).ConfigureAwait(false);

                if (contact?.PersonId != personId)
                {
                    continue;
                }

                _ = await _unitOfWork.ContactRepository.UpdateAsync(item).ConfigureAwait(false);
            }

            _ = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            var result = await _unitOfWork.PersonRepository.GetAsync(personId).ConfigureAwait(false);

            return result is null
                ? throw new ArgumentException("Person not found!")
                : _personMapper.Convert(result);
        }

        public async Task<bool> DeleteContact(List<int> ids)
        {
            foreach (int id in ids)
            {
                _ = await _unitOfWork.ContactRepository.DeleteAsync(id).ConfigureAwait(false);
            }

            int result = await _unitOfWork.CompleteAsync().ConfigureAwait(false);

            return result > 0;
        }

        public async Task<List<ContactTypeDTO?>?> GetContactTypes()
        {
            var result = await _unitOfWork.ContactTypeRepository.GetAllAsync().ConfigureAwait(false);

            return result.ToList().ConvertAll(_contactTypeMapper.Convert);
        }
    }
}
