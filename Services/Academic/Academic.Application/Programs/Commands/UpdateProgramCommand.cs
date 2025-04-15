using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Commands
{
    public class UpdateProgramCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public UpdateProgramCommand(int id, string code, string name, string description)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
        }
    }
}
