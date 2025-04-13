using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByTeacherIdQuery : IRequest<DepartmentResponse>
    {
        public int TeacherId { get; set; }

        public GetDepartmentByTeacherIdQuery(int teacherId)
        {

            TeacherId = teacherId;
        }
    }
}
