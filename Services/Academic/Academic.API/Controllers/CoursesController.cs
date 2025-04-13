using Academic.Application.Courses.Commands;
using Academic.Application.Courses.Queries;
using Academic.Application.Responses.Course;
using BuildingBlocks.Results;
using Core.API.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Academic.API.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> GetAll(CancellationToken cancellationToken)
        {
            GetCoursesQuery query = new();
            IEnumerable<CourseResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseResponse>>.Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HttpResult<CourseResponse>>> GetById(int id, CancellationToken cancellationToken)
        {
            GetCourseByIdQuery query = new(id);
            CourseResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<CourseResponse>.Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<HttpResult<CourseResponse>>> GetByCode(string code, CancellationToken cancellationToken)
        {
            GetCourseByCodeQuery query = new(code);
            CourseResponse result = await _mediator.Send(query, cancellationToken);
            return HttpResult<CourseResponse>.Ok(result);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> GetByName(string name, CancellationToken cancellationToken)
        {
            GetCourseByNameQuery query = new(name);
            IEnumerable<CourseResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseResponse>>.Ok(result);
        }

        [HttpGet("credits/{credits:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> GetByCredits(int credits, CancellationToken cancellationToken)
        {
            GetCourseByCreditsQuery query = new(credits);
            IEnumerable<CourseResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseResponse>>.Ok(result);
        }

        [HttpGet("teacher/{teacherId:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> GetByTeacherId(int teacherId, CancellationToken cancellationToken)
        {
            GetCourseByTeacherIdQuery query = new(teacherId);
            IEnumerable<CourseResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseResponse>>.Ok(result);
        }

        [HttpGet("student/{studentId:int}")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> GetByStudentId(int studentId, CancellationToken cancellationToken)
        {
            GetCourseByStudentIdQuery query = new(studentId);
            IEnumerable<CourseResponse> result = await _mediator.Send(query, cancellationToken);
            return HttpResult<IEnumerable<CourseResponse>>.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<HttpResult<CourseResponse>>> Create([FromBody] CreateCourseCommand command, CancellationToken cancellationToken)
        {
            CourseResponse result = await _mediator.Send(command, cancellationToken);
            return HttpResult<CourseResponse>.Created(result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<HttpResult>> CreateRange([FromBody] IEnumerable<CreateCourseCommand> commands, CancellationToken cancellationToken)
        {
            foreach (CreateCourseCommand command in commands)
            {
                CourseResponse _ = await _mediator.Send(command, cancellationToken);
            }

            return HttpResult.Created();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HttpResult<CourseResponse>>> Update(int id, [FromBody] UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            CourseResponse result = await _mediator.Send(command, cancellationToken);
            return HttpResult<CourseResponse>.Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HttpResult<bool>>> Delete(int id, CancellationToken cancellationToken)
        {
            DeleteCourseCommand command = new(id);
            bool result = await _mediator.Send(command, cancellationToken);
            return HttpResult<bool>.Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult<HttpResult<IEnumerable<CourseResponse>>>> Find([FromQuery] string property, [FromQuery] string value, CancellationToken cancellationToken)
        {
            return HttpResult<IEnumerable<CourseResponse>>.BadRequest("Busca dinâmica ainda não implementada.");
        }
    }
}
