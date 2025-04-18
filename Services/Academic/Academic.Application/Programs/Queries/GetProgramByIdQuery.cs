using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Queries
{
    public class GetProgramByIdQuery : IRequest<ProgramDTO>
    {
        public int Id { get; set; }

        public GetProgramByIdQuery(int id)
        {
            Id = id;
        }
    }
}
