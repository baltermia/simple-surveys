using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleSurveys.Server.Repositories;
using SimpleSurveys.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<Survey>>> Get()
        {
            try
            {
                return Ok(await wrapper.Survey.FindAllAsync());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> Get(int id)
        {
            try
            {
                Survey survey = await wrapper.Survey.FindByIDAsync(id);

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
        public async Task<ActionResult<Survey>> Create(Survey survey)
        {
            try
            {
                Survey created = wrapper.Survey.Create(survey);

                await wrapper.SaveAsync();

                return CreatedAtAction(nameof(Get), new { id = created.ID }, created);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the entity in the database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Survey survey)
        {
            if (id != survey?.ID)
            {
                return BadRequest("Id doesn't match id of entity");
            }

            try
            {
                if (await wrapper.Survey.FindByIDAsync(id) == default(Survey))
                {
                    return NotFound(id);
                }

                wrapper.Survey.Update(survey);

                await wrapper.SaveAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the entity in the database");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Survey survey = await wrapper.Survey.FindByIDAsync(id);

                if (survey == default(Survey))
                {
                    return NotFound(id);
                }

                wrapper.Survey.Delete(survey);
                
                await wrapper.SaveAsync();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting the entity from the database");
            }

            return NoContent();
        }
    }
}
