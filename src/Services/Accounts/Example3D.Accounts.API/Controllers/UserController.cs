﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Example3D.Accounts.Application.Commands;
using Example3D.Accounts.Application.Queries;
using Example3D.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example3D.Accounts.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly IAccountQueries _accountQueries;

        public UserController(IMediator mediator, ILogger<UserController> logger, IAccountQueries accountQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accountQueries = accountQueries ?? throw new ArgumentNullException(nameof(accountQueries));
        }

        [Route("account")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateAccountAsync([FromBody] CreateAccountCommandRequestDto requestDto)
        {
            _logger.LogInformation("CreateAccountAsync");
            bool commandResult = false;

            CreateAccountCommand command = new CreateAccountCommand(requestDto.Name, requestDto.Street, requestDto.City, requestDto.Country);

            commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("accounts")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAccountsAsync()
        {
            try
            {
                var accounts = await _accountQueries.GetAccountsAsync();

                _logger.LogInformation("GetAccountAsync");
                return Ok(accounts);
            }
            catch
            {
                return NotFound();
            }
        }

        [Route("accounts2")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetAccounts2Async()
        {
            try
            {
                AccountQuery query = new AccountQuery();
                var accounts = await _mediator.Send(query, HttpContext.RequestAborted);

                _logger.LogInformation("GetAccountAsync2");
                return Ok(accounts);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
