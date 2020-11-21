using MC.DTO;
using MC.IBLL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MC.WebApi.Controllers
{
    /// <summary>
    /// Contact Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        /// <inheritdoc/>
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <returns>Return list of persons</returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(List<PersonDetailsDTO>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetPersons(string? filterValue, string orderBy = "Id", bool orderAsc = true)
        {
            var result = await _contactService.GetPersons(filterValue, orderBy, orderAsc).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Add Person
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpPost("Create/Person")]
        [ProducesResponseType(typeof(PersonDetailsDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> CreatePerson(CreatePersonDTO request)
        {
            var result = await _contactService.CreatePerson(request).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Add Contact
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpPost("Create/Contact")]
        [ProducesResponseType(typeof(PersonDetailsDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> CreateContact(List<CreateContactDTO> request, int personId)
        {
            var result = await _contactService.CreateContact(request, personId).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Update Person
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpPost("Update/Person")]
        [ProducesResponseType(typeof(PersonDetailsDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdatePerson(EditPersonDTO request)
        {
            var result = await _contactService.UpdatePerson(request).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpPost("Update/Contact")]
        [ProducesResponseType(typeof(PersonDetailsDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateContact(List<EditContactDTO> request, int personId)
        {
            var result = await _contactService.UpdateContact(request, personId).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpDelete("Delete/Person")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeletePerson(int id)
        {
            bool result = await _contactService.DeletePerson(id).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpDelete("Delete/Contact")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteContact(List<int> ids)
        {
            bool result = await _contactService.DeleteContact(ids).ConfigureAwait(false);

            return Ok(result);
        }

        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <returns>Person Details</returns>
        [HttpGet("Get/ContactTypes")]
        [ProducesResponseType(typeof(List<ContactTypeDTO>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetContactTypes()
        {
            var result = await _contactService.GetContactTypes().ConfigureAwait(false);

            return Ok(result);
        }
    }
}
