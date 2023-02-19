using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    [ApiController]
    public class ManageSkillController : Controller
    {
        private readonly ITrainerSkillLogic _logic;
        public ManageSkillController(ITrainerSkillLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("add")]
        public IActionResult AddSkill([FromQuery][BindRequired] string email, Models.UpdateTrainerSkill _data)
        {
            try
            {
                var res = _logic.AddTrainerSkill(email, _data);
                if(res == "max") return BadRequest("reached max");
                if(res == "-1") return BadRequest("something went wrong");
                return Created("added",_data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Accepted();
        }

        [HttpPut("update")]
        public IActionResult UpdateSkill([FromQuery][BindRequired] string email, Models.UpdateTrainerSkill _data, string oldskill)
        {
            try
            {
                var res = _logic.UpdateTrainerSkill(email, _data, oldskill);
                if (res == "-1") return BadRequest("something went wrong");
                else return Ok(_data); 
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Accepted();
        }

        [HttpDelete("delete")]
        public IActionResult DeleteSkill([Required][FromQuery] string email, [Required][FromQuery] string skillname)
        {
            try
            {
                var res = _logic.DeleteTrainerskill(email, skillname);
                if (res == "-1") return BadRequest("something went wrong");
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Accepted();
        }
    }
}
