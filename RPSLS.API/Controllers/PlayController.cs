using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPSLS.API.Requests.Play;
using RPSLS.Application.DTOs;
using RPSLS.Application.Play.Commands;

namespace RPSLS.API.Controllers
{
    [ApiController]
    [Route("play")]
    public class PlayController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PlayRepresentation), StatusCodes.Status200OK)]
        public async Task<PlayRepresentation> Play(PlayRequest request)
        {
            var command = _mapper.Map<PlayRequest, PlayCommand>(request);

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
