using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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
        [HttpGet("ValidateTrainer")]
        public ActionResult Get(string email)
        {
            try
            {
                bool trainer = logic.IsValidLogin(email);
                if(trainer) 
                {
                    return Ok();
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
