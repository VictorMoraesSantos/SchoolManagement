using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Queries
{
    public class GetProgramByCourseQuery : IRequest<ProgramDTO>
    {
        public int CourseId { get; set; }

        public GetProgramByCourseQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
