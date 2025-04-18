using Academic.Application.Courses.Commands;
using Academic.Application.Courses.Handlers;
using Academic.Application.Courses.Queries;
using Academic.Application.Responses.Course;
using BuildingBlocks.Results;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    public class CoursesController : BaseController
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> GetAll(CancellationToken cancellationToken)
        {
            GetCoursesQuery query = new();
            IEnumerable<CourseDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseDto>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<CourseDto>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetCourseByIdQuery query = new(id);
            CourseDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<CourseDto>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<CourseDto>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetCourseByCodeQuery query = new(code);
            CourseDto result = await _mediator.Send(query, cancellationToken);
            return HttpResult<CourseDto>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetCourseByNameQuery query = new(name);
            IEnumerable<CourseDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseDto>>.Ok(result);
        }

        [HttpGet("credits/{credits:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> GetByCredits(int credits, CancellationToken cancellationToken)
        {
            GetCourseByCreditsQuery query = new(credits);
            IEnumerable<CourseDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseDto>>.Ok(result);
        }

        [HttpGet("teacher/{teacherId:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> GetByTeacherId(int teacherId, CancellationToken cancellationToken)
        {
            GetCourseByTeacherIdQuery query = new(teacherId);
            IEnumerable<CourseDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseDto>>.Ok(result);
        }

        [HttpGet("student/{studentId:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> GetByStudentId(int studentId, CancellationToken cancellationToken)
        {
            GetCourseByStudentIdQuery query = new(studentId);
            IEnumerable<CourseDto> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseDto>>.Ok(result);
        }

        [HttpPost("{courseId:int}/department")]
        public async Task<ActionResult<HttpResult<bool>>> AssignToDepartment(int courseId, int departmentId, CancellationToken cancellationToken)
        {
            AssignCourseToDepartmentCommand command = new(courseId, departmentId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost("{courseId:int}/department/{departmentId:int}")]
        public async Task<ActionResult<HttpResult<bool>>> RemoveDepartment(int courseId, int departmentId, CancellationToken cancellationToken)
        {
            RemoveDepartmentFromCourseCommand command = new(courseId, departmentId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost("{courseId:int}/program")]
        public async Task<ActionResult<HttpResult<bool>>> AssignToProgram(int courseId, int programId, CancellationToken cancellationToken)
        {
            AssignCourseToProgramCommand command = new(courseId, programId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost("{courseId:int}/program/{programId:int}")]
        public async Task<ActionResult<HttpResult<bool>>> RemoveProgram(int courseId, int programId, CancellationToken cancellationToken)
        {
            RemoveProgramFromCourseCommand command = new(courseId, programId);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResult<CourseDto>>> Create([FromBody] CreateCourseCommand command, CancellationToken cancellationToken)
        {
            CourseDto result = await _mediator.Send(command, cancellationToken);
            return HttpResult<CourseDto>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateCourseCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateCourseCommand command in commands)
            {
                CourseDto _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Update(int id, [FromBody] UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            UpdateCourseCommand updateCommand = new(id, command.Code, command.Name, command.Description, command.Credits, command.TeacherId);
            bool result = await _mediator.Send(updateCommand, cancellationToken);
            return HttpResult<bool>.Updated(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteCourseCommand command = new(id);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Deleted(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseDto>>>> Find([FromQuery] string property, [FromQuery] string value, CancellationToken cancellationToken)
        {
            return HttpResult<IEnumerable<CourseDto>>.BadRequest("Busca dinâmica ainda não implementada.");
        }
    }
}
