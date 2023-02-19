using LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly Utility _Utility;
        public AuthorizeController(Utility utility)
        {
            _Utility = utility;
        }

        [HttpGet("auth")]
        public IActionResult Authorize(string email, string password)
        {
            if (!_Utility.CheckTrainerExists(email, password))
            {
                return Unauthorized("not found");
            }
            else
            {
                return Redirect("https://localhost:7009/V1/api/Users/all");
            }
        }
    }
}
