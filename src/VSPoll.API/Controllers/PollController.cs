﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VSPoll.API.Models;
using VSPoll.API.Services;

namespace VSPoll.API.Controllers
{
    [Route("poll")]
    [ApiController]
    public class PollController : Controller
    {
        private readonly IPollService pollService;
        public PollController(IPollService pollService)
            => this.pollService = pollService;

        [HttpGet("{id}")]
        public async Task<ActionResult<Poll>> Get(Guid id)
            => await pollService.GetPollAsync(id);

        [HttpPost]
        public async Task<ActionResult<Poll>> Post(PollCreate poll)
            => await pollService.InsertPollAsync(poll);

        //POST poll/vote [bool, user, option]
        //DELETE poll/option [option, user]
    }
}
