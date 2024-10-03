using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RPSLS.API.Requests.Choices;
using RPSLS.Application.Choices.Commands.AddChoices;
using RPSLS.Application.Choices.Queries.GetAllChoices;
using RPSLS.Application.Choices.Queries.GetRandomChoice;
using RPSLS.Application.DTOs;

namespace RPSLS.API.Controllers
{
    [ApiController]
    [Route("")]
    public class ChoicesController(IMediator mediator, IMapper mapper) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        [HttpPost("choice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddChoice(AddChoiceRequest request)
        {
            var command = _mapper.Map<AddChoiceRequest, AddChoiceCommand>(request);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("choices")]
        [ProducesResponseType(typeof(List<ChoiceRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<ChoiceRepresentation>> GetAllChoices()
        {
            var result = await _mediator.Send(new GetAllChoicesQuery());

            return result;
        }

        [HttpGet("choice")]
        [ProducesResponseType(typeof(ChoiceRepresentation), StatusCodes.Status200OK)]
        public async Task<ChoiceRepresentation> GetRandomChoice()
        {
            var result = await _mediator.Send(new GetRandomChoiceQuery());

            return result;
        }

    }
}
