using MC.DTO;
using MC.IBLL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace MC.WebApi.Controllers
{
    /// <summary>
    /// Test Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        /// <inheritdoc/>
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        /// <summary>
        /// Get Test
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [ProducesResponseType(typeof(TestDTO), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetFirst()
        {
            var result = await _testService.Get().ConfigureAwait(false);

            return Ok(result);
        }
    }
}
