using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Queries
{
    public class GetProgramsQuery : IRequest<IEnumerable<ProgramResponse>>
    {
        public GetProgramsQuery()
        {
        }
    }
}
