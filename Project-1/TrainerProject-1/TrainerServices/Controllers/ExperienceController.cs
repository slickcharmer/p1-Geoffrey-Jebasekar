using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        ILogic logic;
        public ExperienceController(ILogic _logic)
        {
            logic = _logic;
        }

        [HttpPost("AddTrainerExperience")]
        public ActionResult Add([FromBody] Trainer_Companies experience)
        {
            //experience.emailid = email;
            try
            {
                logic.AddC(experience);

                return Ok("Trainer experience Added Successfully");

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
        [HttpGet("GetTrainersExperience")]
        public ActionResult Get(string email)
        {
            try
            {
                var trainers = logic.GetTrainersExperience(email);


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
        [HttpGet("GetTrainersExperienceByExp")]
        public ActionResult Get(string email, string exp, string title)
        {
            try
            {
                var trainers = logic.GetTrainersExperience(email, exp, title);


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
        [HttpDelete("DeleteTrainersExperience")]
        public ActionResult Delete(string email, string companyName,string title)
        {
            try
            {
                logic.DeleteExperience(email, companyName, title);


                return Ok("Experience deleted successfully");


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
        [HttpPut("UpdateTrainersExperience")]
        public ActionResult Update([FromBody] Trainer_Companies experience, string email, string companyName, string title)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    logic.UpdateExperience(experience, email, companyName, title);
                    return Ok(experience);
                }
                else
                {
                    return BadRequest($"Something went wrong");
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
