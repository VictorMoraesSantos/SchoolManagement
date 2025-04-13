using Academic.Application.Departaments.Commands;
using Academic.Application.Departaments.Queries;
using Academic.Application.Responses.Department;
using BuildingBlocks.Results;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    public class DepartmentsController : ApiController
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HttpResult<IEnumerable<DepartmentResponse>>>> GetAll(CancellationToken cancellationToken)
        {
            GetDepartmentsQuery query = new();
            IEnumerable<DepartmentResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<DepartmentResponse>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetDepartmentByIdQuery query = new(id);
            DepartmentResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentResponse>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetDepartmentByCodeQuery query = new(code);
            DepartmentResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentResponse>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<DepartmentResponse>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetDepartmentByNameQuery query = new(name);
            IEnumerable<DepartmentResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<DepartmentResponse>>.Ok(result);
        }

        [HttpGet("teacher/{teacherId:int}")]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> GetByTeacherId(int teacherId, CancellationToken cancellationToken)
        {
            GetDepartmentByTeacherIdQuery query = new(teacherId);
            DepartmentResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentResponse>.Ok(result);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> GetByCourse(int courseId, CancellationToken cancellationToken)
        {
            GetDepartmentByCourseQuery query = new(courseId);
            DepartmentResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentResponse>.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> Create([FromBody] CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            DepartmentResponse result = await _mediator.Send(command, cancellationToken);
            return HttpResult<DepartmentResponse>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateDepartmentCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateDepartmentCommand command in commands)
            {
                DepartmentResponse _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<DepartmentResponse>>> Update(int id, [FromBody] UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            DepartmentResponse result = await _mediator.Send(command, cancellationToken);
            return HttpResult<DepartmentResponse>.Updated(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteDepartmentCommand command = new(id);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Deleted(result);
        }
    }
}