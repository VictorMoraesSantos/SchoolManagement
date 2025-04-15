using Academic.Application.Exceptions;
using Academic.Application.Programs.Commands;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class RemoveCourseInProgramCommandHandler : IRequestHandler<ModifyCourseInProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;
        private readonly ICourseRepository _courseRepository;

        public RemoveCourseInProgramCommandHandler(IProgramRepository programRepository, ICourseRepository courseRepository)
        {
            _programRepository = programRepository;
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(ModifyCourseInProgramCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.CourseId);

            Program? program = await _programRepository.GetById(command.ProgramId, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(command.ProgramId);

            program.RemoveCourse(course);
            await _programRepository.Update(program, cancellationToken);

            return true;
        }
    }
}
