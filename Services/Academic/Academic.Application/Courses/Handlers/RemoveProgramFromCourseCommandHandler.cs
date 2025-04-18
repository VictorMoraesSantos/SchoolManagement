using Academic.Application.Courses.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class RemoveProgramFromCourseCommandHandler : IRequestHandler<RemoveProgramFromCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public RemoveProgramFromCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(RemoveProgramFromCourseCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.CourseId);

            course.RemoveProgram();
            await _courseRepository.Update(course, cancellationToken);

            return true;
        }
    }
}
