using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Commands;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class CreateProgramCommandHandler : IRequestHandler<CreateProgramCommand, ProgramDTO>
    {
        private readonly IProgramRepository _programRepository;

        public CreateProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<ProgramDTO> Handle(CreateProgramCommand command, CancellationToken cancellationToken)
        {
            Program? programExists = await _programRepository.GetByCode(command.Code, cancellationToken);
            if (programExists != null)
                throw new ProgramAlreadyExistsException(command.Code, $"Já existe um programa com o código '{command.Code}'.");

            Program program = new Program(command.Code, command.Name, command.Description);
            await _programRepository.Create(program, cancellationToken);

            return ProgramMapper.ToResponse(program);
        }
    }
}
