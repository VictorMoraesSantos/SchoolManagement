using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByTeacherIdQuery : IRequest<DepartmentDto>
    {
        public int TeacherId { get; set; }

        public GetDepartmentByTeacherIdQuery(int teacherId)
        {

            TeacherId = teacherId;
        }
    }
}
