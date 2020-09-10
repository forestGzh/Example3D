using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Example3D.Books.Application.Commands;
using Example3D.Books.Application.Queries;
using Example3D.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example3D.Books.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookController> _logger;
        private readonly IBookQueries _bookQueries;

        public BookController(IMediator mediator, ILogger<BookController> logger, IBookQueries bookQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookQueries = bookQueries ?? throw new ArgumentNullException(nameof(bookQueries));
        }

        [Route("book")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateBookAsync([FromBody] CreateBookCommandRequestDto requestDto)
        {
            _logger.LogInformation("CreateBookAsync");
            bool commandResult = false;

            CreateBookCommand command = new CreateBookCommand(requestDto.Name, requestDto.Quantity);

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
                var books = await _bookQueries.GetBooksAsync();

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
