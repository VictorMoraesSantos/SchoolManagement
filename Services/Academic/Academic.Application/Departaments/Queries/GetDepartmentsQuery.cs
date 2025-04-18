using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public GetDepartmentsQuery()
        {
        }
    }
}
