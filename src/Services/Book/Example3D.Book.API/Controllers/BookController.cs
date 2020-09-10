using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Example3D.Book.Application.Commands;
using Example3D.Book.Application.Queries;
using Example3D.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example3D.Book.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookController> _logger;
        private readonly IBookEntityQueries _bookEntityQueries;

        public BookController(IMediator mediator, ILogger<BookController> logger, IBookEntityQueries bookEntityQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookEntityQueries = bookEntityQueries ?? throw new ArgumentNullException(nameof(bookEntityQueries));
        }

        [Route("book")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateBookEntityAsync([FromBody] CreateBookEntityCommandRequestDto requestDto)
        {
            _logger.LogInformation("CreateBookEntityAsync");
            bool commandResult = false;

            CreateBookEntityCommand command = new CreateBookEntityCommand(requestDto.Name, requestDto.Quantity);

            commandResult = await _mediator.Send(command);

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("books")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateBooksAsync()
        {
            try
            {
                var books = await _bookEntityQueries.GetBooksAsync();

                _logger.LogInformation("GetBooksAsync");
                return Ok(books);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
