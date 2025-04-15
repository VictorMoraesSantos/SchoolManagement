using Academic.Application.Exceptions;
using Academic.Application.Programs.Commands;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Programs.Handlers
{
    public class DeleteProgramCommandHandler : IRequestHandler<DeleteProgramCommand, bool>
    {
        private readonly IProgramRepository _programRepository;

        public DeleteProgramCommandHandler(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }

        public async Task<bool> Handle(DeleteProgramCommand command, CancellationToken cancellationToken)
        {
            Program? program = await _programRepository.GetById(command.Id, cancellationToken);
            if (program == null)
                throw new ProgramNotFoundException(command.Id);

            program.MarkAsDeleted();
            await _programRepository.Update(program, cancellationToken);
            
            return true;
        }
    }
}
