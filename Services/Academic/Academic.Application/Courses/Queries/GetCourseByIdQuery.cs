using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByIdQuery : IRequest<CourseResponse>
    {
        public int Id { get; }

        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
