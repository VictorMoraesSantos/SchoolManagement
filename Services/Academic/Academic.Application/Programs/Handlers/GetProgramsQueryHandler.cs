using Academic.Application.Mappers;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class GetProgramsQueryHandler : IRequestHandler<GetProgramsQuery, IEnumerable<ProgramDTO>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramsQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<ProgramDTO>> Handle(GetProgramsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Program> programs = await _programRepository.GetAll(cancellationToken);

            IEnumerable<ProgramDTO> programsResponse = programs.Select(ProgramMapper.ToResponse);

            return programsResponse;
        }
    }
}
