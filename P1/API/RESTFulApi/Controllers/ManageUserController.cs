using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace RESTFulApiBasics.Controllers
{
    [Route("V1/api/[controller]")]
    [ApiController]
    public class ManageUserController : Controller
    {
        private readonly ITrainerDetailLogic _logic;
        public ManageUserController(ITrainerDetailLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("me/{email}")]
        public IActionResult GetMe([BindRequired][FromRoute] string email)
        {
            try
            {
                var Me = new List<Models.All>();
                Me = _logic.GetMe(email).ToList();
                if (Me.IsNullOrEmpty()) return BadRequest("something went wrong");
                else return Ok(Me);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateTrainerDetails([BindRequired] string email, [BindRequired][FromBody]Models.TrainerUpdate t)
        {
            try
            {
                var res = _logic.UpdateTrainerDetails(email, t);
                if (res == "-1") return BadRequest("something went wrong");
                else return Ok(t);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery][BindRequired] Models.DeleteTrainer t)
        {
            try
            {
                var res = _logic.DeleteTrainerDetails(t);
                if (res == "-1") return BadRequest("something went worng");
                else return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
