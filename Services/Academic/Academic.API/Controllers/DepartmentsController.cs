using Academic.Application.Departaments.Commands;
using Academic.Application.Departaments.Queries;
using Academic.Application.Programs.Commands;
using Academic.Application.Responses.Department;
using BuildingBlocks.Results;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    public class DepartmentsController : BaseController
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HttpResult<IEnumerable<DepartmentDto>>>> GetAll(CancellationToken cancellationToken)
        {
            GetDepartmentsQuery query = new();
            IEnumerable<DepartmentDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<DepartmentDto>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetDepartmentByIdQuery query = new(id);
            DepartmentDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentDto>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetDepartmentByCodeQuery query = new(code);
            DepartmentDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentDto>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<DepartmentDto>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetDepartmentByNameQuery query = new(name);
            IEnumerable<DepartmentDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<DepartmentDto>>.Ok(result);
        }

        [HttpGet("teacher/{teacherId:int}")]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> GetByTeacherId(int teacherId, CancellationToken cancellationToken)
        {
            GetDepartmentByTeacherIdQuery query = new(teacherId);
            DepartmentDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentDto>.Ok(result);
        }

        [HttpGet("course/{courseId:int}")]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> GetByCourse(int courseId, CancellationToken cancellationToken)
        {
            GetDepartmentByCourseQuery query = new(courseId);
            DepartmentDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<DepartmentDto>.Ok(result);
        }

        [HttpPost("{departmentId:int}/teachers")]
        public async Task<ActionResult<HttpResult<bool>>> AddTeacherToDepartment(int departmentId, [FromBody] AssignTeacherToDepartmentCommand command, CancellationToken cancellationToken)
        {
            AssignTeacherToDepartmentCommand addCourseCommand = new(departmentId, command.TeacherId);
            bool result = await _mediator.Send(addCourseCommand, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost("{departmentId:int}/teachers/{teacherId:int}")]
        public async Task<ActionResult<HttpResult<bool>>> RemoveTeacherFromDepartment(int departmentId, int teacherId, CancellationToken cancellationToken)
        {
            RemoveTeacherFromDepartmentCommand command = new(departmentId, teacherId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> Create([FromBody] CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            DepartmentDto result = await _mediator.Send(command, cancellationToken);
            return HttpResult<DepartmentDto>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateDepartmentCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateDepartmentCommand command in commands)
            {
                DepartmentDto _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<DepartmentDto>>> Update(int id, [FromBody] UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            DepartmentDto result = await _mediator.Send(command, cancellationToken);
            return HttpResult<DepartmentDto>.Updated(result);
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