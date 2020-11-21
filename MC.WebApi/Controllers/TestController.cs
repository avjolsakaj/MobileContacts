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
        /// Get Test
        /// </summary>
        /// <returns>Return list of persons</returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(List<PersonDTO>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetPersons(string? filterValue, string orderBy = "Id", bool orderAsc = true)
        {
            var result = await _contactService.GetPersons(filterValue, orderBy, orderAsc).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
