using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    public class ManageLocationController : Controller
    {
        private readonly ITrainerLocationLogic _logic;
        public ManageLocationController(ITrainerLocationLogic logic) {
            _logic = logic;
        }
        [HttpPost("add")]
        public IActionResult AddLocation([FromQuery][Required]string email, [FromBody] Models.EditTrainerLocation t)
        {
            var res = _logic.AddTrainerLocation(email, t);
            if (res == "-1") return BadRequest("something went wrong, check your email");
            return Created("OK", t);
        }

        [HttpPut("update")]
        public IActionResult UpdateLocation([FromQuery][Required] string email, [FromBody] Models.EditTrainerLocation t)
        {
            var res = _logic.UpdateTrainerLocation(t, email);
            if(res == "-1") return BadRequest("something went wrong, check your email");
            return Created("OK", t);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteLocation([FromQuery][Required] string email) {
            var res = _logic.DeleteTrainerLocation(email);
            if (res == "-1") return BadRequest("something went wrong, check your email");
            return NoContent();
        }
    }
}
