using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Programs.Commands;
using Academic.Application.Responses.Program;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class UpdateProgramCommandHandler : IRequestHandler<UpdateProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;

        public UpdateProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<bool> Handle(UpdateProgramCommand command, CancellationToken cancellationToken)
        {
            Program? program = await _programRepository.GetById(command.Id, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(command.Id);

            program.SetCode(command.Code);
            program.SetName(command.Name);
            program.SetDescription(command.Description);

            program.MarkAsUpdated();

            return true;
        }
    }
}
