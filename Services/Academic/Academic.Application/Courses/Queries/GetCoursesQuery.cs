using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {

    }
}
