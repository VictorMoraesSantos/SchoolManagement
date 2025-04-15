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
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramResponse>>>> GetAll(CancellationToken cancellationToken)
        {
            GetProgramsQuery query = new();
            IEnumerable<ProgramResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<ProgramResponse>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<ProgramResponse>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetProgramByIdQuery query = new(id);
            ProgramResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramResponse>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<ProgramResponse>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetProgramByCodeQuery query = new(code);
            ProgramResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramResponse>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramResponse>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetProgramByNameQuery query = new(name);
            IEnumerable<ProgramResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<ProgramResponse>>.Ok(result);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<ActionResult<HttpResult<ProgramResponse>>> GetByCourse(int courseId, CancellationToken cancellationToken)
        {
            GetProgramByCourseQuery query = new(courseId);
            ProgramResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<ProgramResponse>.Ok(result);
        }

        [HttpPost("course/{programId:int}/courses")]
        public async Task<ActionResult<HttpResult<bool>>> AddCourseToProgram(int programId, [FromBody] ModifyCourseInProgramCommand command, CancellationToken cancellationToken)
        {
            ModifyCourseInProgramCommand addCourseCommand = new(programId, command.CourseId);
            bool result = await _mediator.Send(addCourseCommand, cancellationToken);
            return HttpResult<bool>.Ok(result);
        }

        [HttpPost("course/{programId:int}/courses/{courseId:int}")]
        public async Task<ActionResult<HttpResult<bool>>> RemoveCourseFromProgram(int programId, int courseId, CancellationToken cancellationToken)
        {
            ModifyCourseInProgramCommand command = new(programId, courseId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<HttpResult<ProgramResponse>>> Create([FromBody] CreateProgramCommand command, CancellationToken cancellationToken)
        {
            ProgramResponse result = await _mediator.Send(command, cancellationToken);
            return HttpResult<ProgramResponse>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateProgramCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateProgramCommand command in commands)
            {
                ProgramResponse _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Update(int id, [FromBody] UpdateProgramCommand command, CancellationToken cancellationToken)
        {
            UpdateProgramCommand updateCommand = new(id, command.Code, command.Name, command.Description);
            bool result = await _mediator.Send(updateCommand, cancellationToken);
            return HttpResult<bool>.Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteProgramCommand command = new(id);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<HttpResult<IEnumerable<ProgramResponse>>>> Find([FromQuery] string property, [FromQuery] string value, CancellationToken cancellationToken)
        {
            return HttpResult<IEnumerable<ProgramResponse>>.BadRequest("Busca dinâmica ainda não implementada.");
        }
    }
}