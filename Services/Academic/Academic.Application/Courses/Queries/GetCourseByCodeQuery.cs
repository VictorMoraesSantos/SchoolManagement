using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByCodeQuery : IRequest<CourseDto>
    {
        public string Code { get; set; }

        public GetCourseByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
