using Academic.Application.Responses;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCoursesQuery : IRequest<IEnumerable<CourseResponse>>
    {

    }
}
