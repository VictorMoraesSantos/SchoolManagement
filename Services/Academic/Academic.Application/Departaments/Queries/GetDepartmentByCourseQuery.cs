using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByCourseQuery : IRequest<DepartmentResponse>
    {
        public int CourseId { get; set; }

        public GetDepartmentByCourseQuery(int courseId)
        {
            CourseId = courseId;
        }
    }
}
