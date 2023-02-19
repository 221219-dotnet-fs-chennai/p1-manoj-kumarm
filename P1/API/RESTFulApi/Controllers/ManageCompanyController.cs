using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    public class ManageCompanyController : Controller
    {
        private readonly ITrainerCompanyLogic _logic;
        public ManageCompanyController(ITrainerCompanyLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("add")]
        public IActionResult AddCompany([FromQuery][Required] string email, [FromBody]Models.AddTrainerCompany t)
        {
            var res = _logic.AddTrainerCompany(email, t);
            if(res == "-1") return BadRequest("something went wrong");
            return Ok(t);
        }

        [HttpPut("update")]
        public IActionResult UpdateCompany([FromQuery] [Required]string email, [FromQuery][Required] string companyName, [FromBody]Models.UpdateTrainerCompany t)
        {
            var res = _logic.UpdateTrainerCompany(email, companyName, t);
            if (res == null) return BadRequest("something went wrong");
            return Ok(res);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteCompany([FromQuery][Required] string email, [FromQuery][Required] string comapanyName)
        {
            var res = _logic.DeleteTrainerCompany(email, comapanyName);
            if (res == "-1") return BadRequest("something went wrong");
            return NoContent();
        }
    }
}
