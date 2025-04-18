using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Queries
{
    public class GetProgramByCodeQuery : IRequest<ProgramDTO>
    {
        public string Code { get; set; }

        public GetProgramByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
