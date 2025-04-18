using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class GetProgramByCourseQueryHandler : IRequestHandler<GetProgramByCourseQuery, ProgramDTO>
    {
        private readonly IProgramRepository _programRepository;
        private readonly ICourseRepository _courseRepository;

        public GetProgramByCourseQueryHandler(IProgramRepository programRepository, ICourseRepository courseRepository)
        {
            _programRepository = programRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ProgramDTO> Handle(GetProgramByCourseQuery query, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(query.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(query.CourseId);

            Program? program = await _programRepository.GetByCourse(course, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(course.Id);

            ProgramDTO programResponse = ProgramMapper.ToResponse(program);
            return programResponse;
        }
    }
}
