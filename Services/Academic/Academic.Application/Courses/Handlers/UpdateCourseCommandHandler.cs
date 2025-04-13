using Academic.Application.Courses.Commands;
using Academic.Application.Mappers;
using Academic.Application.Responses;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using Core.Domain.Exceptions;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.Id, cancellationToken);
            if (course == null)
                throw new DomainException($"Course with ID {command.Id} not found.");

            course.SetCode(command.Code);
            course.SetName(command.Name);
            course.SetDescription(command.Description);
            course.SetCredits(command.Credits);
            course.AssignTeacher(command.TeacherId);
            course.AddStudent(command.StudentId);

            course.MarkAsUpdated();

            await _courseRepository.Update(course, cancellationToken);
            return CourseMapper.ToResponse(course);
        }
    }
}
