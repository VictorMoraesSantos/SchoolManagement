using Academic.Application.Responses;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByCreditsQuery : IRequest<IEnumerable<CourseResponse>>
    {
        public int Credits { get; set; }

        public GetCourseByCreditsQuery(int credits)
        {
            Credits = credits;
        }
    }
}
