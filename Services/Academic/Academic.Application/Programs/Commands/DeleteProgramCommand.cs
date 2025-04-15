using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Commands
{
    public class DeleteProgramCommand : IRequest<bool>
    {
        public int Id { get; init; }

        public DeleteProgramCommand(int id)
        {
            Id = id;
        }
    }
}
