using Academic.Application.Courses.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class AssignCourseToProgramCommandHandler : IRequestHandler<AssignCourseToProgramCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IProgramRepository _programRepository;

        public AssignCourseToProgramCommandHandler(ICourseRepository courseRepository, IProgramRepository programRepository)
        {
            _courseRepository = courseRepository;
            _programRepository = programRepository;
        }

        public async Task<bool> Handle(AssignCourseToProgramCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.CourseId);

            Program? program = await _programRepository.GetById(command.ProgramId, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(command.ProgramId);

            course.SetProgram(program);
            await _courseRepository.Update(course, cancellationToken);

            return true;
        }
    }
}
