using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Commands
{
    public class CreateProgramCommand : IRequest<ProgramDTO>
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }

        public CreateProgramCommand(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }
    }
}
