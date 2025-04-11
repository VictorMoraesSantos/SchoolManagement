using Academic.Application.Courses.Commands;
using Academic.Application.Mappers;
using Academic.Application.Responses;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            Course course = new Course(command.Code, command.Name, command.Description, command.Credits, command.TeacherId);
            await _courseRepository.Create(course, cancellationToken);

            return CourseMapper.ToResponse(course);
        }
    }
}
