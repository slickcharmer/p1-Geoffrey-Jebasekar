using BusinessLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogic logic;

        public LoginController(ILogic logic)
        {
            this.logic = logic;
        }
        [EnableCors("corspolicy")]
        [HttpGet("ValidateTrainer")]
        public ActionResult Get(string Email, string Pass)
        {
            try
            {
                var trainer = logic.IsValidLogin(Email,Pass);
                 if(!trainer.IsNullOrEmpty())
                {
                    return Ok(trainer);
                }
                else
                {
                    return BadRequest("Check your credentials");
                }
                
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
                
            } 
      
        }
    }
}
