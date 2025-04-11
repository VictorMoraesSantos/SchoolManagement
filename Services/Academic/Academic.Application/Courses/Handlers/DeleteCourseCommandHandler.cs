using Academic.Application.Courses.Commands;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using Core.Domain.Exceptions;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
        {
            Course course = await _courseRepository.GetById(command.Id, cancellationToken);
            if (course == null)
                throw new DomainException($"Course with ID {command.Id} not found.");

            course.MarkAsDeleted();
            await _courseRepository.Update(course, cancellationToken);

            return true;
        }
    }
}
