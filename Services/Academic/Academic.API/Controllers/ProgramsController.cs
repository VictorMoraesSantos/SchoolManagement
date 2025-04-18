using Academic.Application.Programs.Commands;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using BuildingBlocks.Results;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    public class ProgramsController : BaseController
    {
        private readonly IMediator _mediator;

        public ProgramsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramDTO>>>> GetAll(CancellationToken cancellationToken)
        {
            GetProgramsQuery query = new();
            IEnumerable<ProgramDTO> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<ProgramDTO>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<ProgramDTO>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetProgramByIdQuery query = new(id);
            ProgramDTO result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramDTO>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<ProgramDTO>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetProgramByCodeQuery query = new(code);
            ProgramDTO result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramDTO>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramDTO>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetProgramByNameQuery query = new(name);
            IEnumerable<ProgramDTO> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<ProgramDTO>>.Ok(result);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<ActionResult<HttpResult<ProgramDTO>>> GetByCourse(int courseId, CancellationToken cancellationToken)
        {
            GetProgramByCourseQuery query = new(courseId);
            ProgramDTO result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramDTO>.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResult<ProgramDTO>>> Create([FromBody] CreateProgramCommand command, CancellationToken cancellationToken)
        {
            ProgramDTO result = await _mediator.Send(command, cancellationToken);
            return HttpResult<ProgramDTO>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateProgramCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateProgramCommand command in commands)
            {
                ProgramDTO _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Update(int id, [FromBody] UpdateProgramCommand command, CancellationToken cancellationToken)
        {
            UpdateProgramCommand updateCommand = new(id, command.Code, command.Name, command.Description);
            bool result = await _mediator.Send(updateCommand, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteProgramCommand command = new(id);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Deleted(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramDTO>>>> Find([FromQuery] string property, [FromQuery] string value, CancellationToken cancellationToken)
        {
            return HttpResult<IEnumerable<ProgramDTO>>.BadRequest("Busca dinâmica ainda não implementada.");
        }
    }
}