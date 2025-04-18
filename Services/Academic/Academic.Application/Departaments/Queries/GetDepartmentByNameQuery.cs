using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByNameQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public string Name { get; set; }

        public GetDepartmentByNameQuery(string name)
        {
            Name = name;
        }
    }
}
