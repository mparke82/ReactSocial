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
            return Ok();
        }
    }
}