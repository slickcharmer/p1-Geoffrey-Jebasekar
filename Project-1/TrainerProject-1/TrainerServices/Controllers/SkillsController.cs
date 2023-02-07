using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace TrainerServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        ILogic logic;
        public SkillsController(ILogic _logic) 
        {
            logic= _logic;
        }
        [HttpPost("AddTrainerSkills")]
        public ActionResult Add(Trainer_Skills skills,string email)
        {
            skills.emailid = email;
            try
            {
                logic.AddSk(skills);

                return Ok("Trainer skill Added Successfully");

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
        [HttpGet("GetTrainersSkills")]
        public ActionResult Get(string email)
        {
            try
            {
                var trainers = logic.GetTrainersSkills(email);


                return Ok(""+trainers);


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
        [HttpDelete("DeleteTrainerSkills")]
        public ActionResult Delete(string email,string skill)
        {
            try
            {
                logic.DeleteSkill(email, skill);


                return Ok("Skill deleted successfully");


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
