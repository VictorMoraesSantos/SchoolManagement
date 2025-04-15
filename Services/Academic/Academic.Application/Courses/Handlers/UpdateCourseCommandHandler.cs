using Academic.Application.Courses.Commands;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.Id, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.Id);

            course.SetCode(command.Code);
            course.SetName(command.Name);
            course.SetDescription(command.Description);
            course.SetCredits(command.Credits);
            course.AssignTeacher(command.TeacherId);

            course.MarkAsUpdated();

            await _courseRepository.Update(course, cancellationToken);
            return true;
        }
    }
}
