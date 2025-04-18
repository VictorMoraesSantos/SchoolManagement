using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByStudentIdQuery : IRequest<IEnumerable<CourseDto>>
    {
        public int Id { get; set; }

        public GetCourseByStudentIdQuery(int id)
        {
            Id = id;
        }
    }
}
