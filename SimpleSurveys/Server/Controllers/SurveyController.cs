using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSurveys.Server.Repositories;
using SimpleSurveys.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSurveys.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class SurveyController : Controller
    {
        private readonly IRepositoryWrapper wrapper;

        public SurveyController(IRepositoryWrapper wrapper)
        {
            this.wrapper = wrapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Survey>> Get()
        {
            try
            {
                return Ok(wrapper.Survey.FindAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Survey> Get(long id)
        {
            try
            {
                Survey survey = GetById(id);

                if (survey == default(Survey))
                {
                    return NotFound(id);
                }

                return Ok(survey);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public ActionResult<Survey> Create(Survey survey)
        {
            try
            {
                Survey created = wrapper.Survey.Create(survey);
                wrapper.Save();

                return CreatedAtAction(nameof(Get), new { id = created.ID }, created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the entity in the database");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update(long id, Survey survey)
        {
            if (id != survey?.ID)
            {
                return BadRequest("Id doesn't match id of entity");
            }

            try
            {
                if (GetById(id) == default(Survey))
                {
                    return NotFound(id);
                }

                wrapper.Survey.Update(survey);
                wrapper.Save();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the entity in the database");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                Survey survey = GetById(id);

                if (survey == default(Survey))
                {
                    return NotFound(id);
                }

                wrapper.Survey.Delete(survey);
                wrapper.Save();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the entity from the database");
            }

            return NoContent();
        }

        private Survey GetById(long id) => wrapper.Survey.FindByCondition(s => s.ID == id).FirstOrDefault();
    }
}
