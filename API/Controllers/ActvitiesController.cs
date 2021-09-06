using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        // Return a list of our activities
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            // Mediator is inherited from BaseApiController
            return await Mediator.Send(new List.Query());
        }

        // {id} is a root parameter
        [HttpGet("{id}")] // activities/id
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        // IActionResult gives us access to the HTTP response type
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }
    }
}