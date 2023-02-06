using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        ILogic logic;
        //Trainer_Login login = new Trainer_Login();
        public EducationController(ILogic _logic)
        {
            logic = _logic;
        }
        [HttpPost("AddTrainerEducation")]
        public ActionResult Add(Trainer_Education education,string email)
        {
            education.emailid = email;
            try
            {
                logic.AddE(education);
                
                return Ok("Trainer education Added Successfully");
              
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
        [HttpGet("GetTrainersEducation")]
        public ActionResult Get(string email)
        {
            try
            {
                var trainers = logic.GetTrainersEducation(email);
                
                
               return Ok(trainers);
                
                
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
