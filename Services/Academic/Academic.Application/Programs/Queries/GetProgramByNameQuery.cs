using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Queries
{
    public class GetProgramByNameQuery : IRequest<IEnumerable<ProgramDTO>>
    {
        public string Name { get; set; }

        public GetProgramByNameQuery(string name)
        {
            Name = name;
        }
    }
}
