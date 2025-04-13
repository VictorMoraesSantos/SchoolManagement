using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByNameQuery : IRequest<IEnumerable<CourseResponse>>
    {
        public string Name { get; set; }

        public GetCourseByNameQuery(string name)
        {
            Name = name;
        }
    }
}
