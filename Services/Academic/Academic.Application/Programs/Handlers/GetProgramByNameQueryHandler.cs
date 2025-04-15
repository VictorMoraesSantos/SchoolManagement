using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class GetProgramByNameQueryHandler : IRequestHandler<GetProgramByNameQuery, IEnumerable<ProgramResponse>>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramByNameQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<IEnumerable<ProgramResponse>> Handle(GetProgramByNameQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Program> programs = await _programRepository.GetByName(query.Name, cancellationToken);
            if (programs == null)
                throw new ProgramNotFoundException(query.Name);

            IEnumerable<ProgramResponse> programsResponse = programs.Select(ProgramMapper.ToResponse);

            return programsResponse;
        }
    }
}
