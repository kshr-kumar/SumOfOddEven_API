using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Runtime.Serialization;

namespace SumOfOddEven.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SumOfOddEvenController : ControllerBase
    {

        [HttpPost]
        public IActionResult GetSum(SumRequest request)
        {
            if (request == null || request.Numbers == null || !request.Numbers.Any())
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            int sum;
            if (request.Type.ToLower() == "odd")
            {
                sum = request.Numbers.Where(n => n % 2 != 0).Sum();
                return StatusCode(StatusCodes.Status201Created, new { Result = sum });
            }
            else if (request.Type.ToLower() == "even")
            {
                sum = request.Numbers.Where(n => n % 2 == 0).Sum();
                return StatusCode(StatusCodes.Status201Created, new { Result = sum });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
