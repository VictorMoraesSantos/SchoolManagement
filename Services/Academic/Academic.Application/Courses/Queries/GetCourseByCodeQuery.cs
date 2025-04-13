using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByCodeQuery : IRequest<CourseResponse>
    {
        public string Code { get; set; }

        public GetCourseByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
