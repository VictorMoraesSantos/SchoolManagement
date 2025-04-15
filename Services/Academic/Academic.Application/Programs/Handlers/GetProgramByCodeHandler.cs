using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class GetProgramByCodeHandler : IRequestHandler<GetProgramByCodeQuery, ProgramResponse>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramByCodeHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramResponse> Handle(GetProgramByCodeQuery query, CancellationToken cancellationToken)
        {
            Program? program = await _programRepository.GetByCode(query.Code, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(query.Code);

            ProgramResponse programResponse = ProgramMapper.ToResponse(program);

            return programResponse;
        }
    }
}
