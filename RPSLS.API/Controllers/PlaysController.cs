using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPSLS.API.Requests.Plays;
using RPSLS.Application.Plays.Commands.AddPlay;

namespace RPSLS.API.Controllers
{
    [ApiController]
    [Route("play")]
    public class PlaysController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPlay(AddPlayRequest request)
        {
            var command = _mapper.Map<AddPlayRequest, AddPlayCommand>(request);

            await _mediator.Send(command);

            return Ok();
        }
    }
}
