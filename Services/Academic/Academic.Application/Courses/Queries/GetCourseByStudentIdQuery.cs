using Academic.Application.Responses.Course;
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
