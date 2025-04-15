using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Queries;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class GetProgramByIdQueryHandler : IRequestHandler<GetProgramByIdQuery, ProgramResponse>
    {
        private readonly IProgramRepository _programRepository;

        public GetProgramByIdQueryHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramResponse> Handle(GetProgramByIdQuery query, CancellationToken cancellationToken)
        {
            Program? program = await _programRepository.GetById(query.Id, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(query.Id);

            ProgramResponse programResponse = ProgramMapper.ToResponse(program);

            return programResponse;
        }
    }
}
