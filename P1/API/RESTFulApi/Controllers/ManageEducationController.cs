using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    [ApiController]
    public class ManageEducationController : ControllerBase
    {
        private readonly ITrainerEducationLogic _logic;
        public ManageEducationController(ITrainerEducationLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("add")]
        public IActionResult AddEducation([FromQuery][Required] string email, [FromBody] Models.AddTrainerEducation t)
        {
            var res = _logic.AddTrainerEducation(email, t);
            if(res =="max") return BadRequest("reached max");
            if(res == "-1") return BadRequest(res);
            return Created("ok",t);
        }
        
        [HttpPut("update")]
        public IActionResult UpdateEducation([FromQuery][Required] string email, [FromQuery][Required] string eduname, [FromBody] Models.UpdateTrainerEducation t)
        {
            var res = _logic.UpdateTrainerEducation(email.Trim(), eduname, t);
            if (res == "-1") return BadRequest(res);
            return Ok(t);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteEducation([FromQuery][Required] string email, [FromQuery][Required] string eduname)
        {
            var res = _logic.DeleteTrainerEducation(email, eduname);
            if (res == "-1") return BadRequest(res);
            return NoContent();
        }
    }
}
