using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByCreditsQuery : IRequest<IEnumerable<CourseDto>>
    {
        public int Credits { get; set; }

        public GetCourseByCreditsQuery(int credits)
        {
            Credits = credits;
        }
    }
}
