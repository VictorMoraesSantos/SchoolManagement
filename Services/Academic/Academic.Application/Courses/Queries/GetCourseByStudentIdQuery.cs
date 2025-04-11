using Academic.Application.Responses;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByStudentIdQuery : IRequest<IEnumerable<CourseResponse>>
    {
        public int Id { get; set; }

        public GetCourseByStudentIdQuery(int id)
        {
            Id = id;
        }
    }
}
