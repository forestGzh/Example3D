using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Example3D.Account.Application.Commands;
using Example3D.Account.Application.Queries;
using Example3D.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example3D.Account.API.Controllers
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

        //[HttpGet("time")]
        //public ActionResult<object> Get()
        //{
        //    return DateTime.Now.ToString();
        //}

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
        public async Task<ActionResult> CreateAccountsAsync()
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
    }
}
