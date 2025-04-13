using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByIdQuery : IRequest<DepartmentResponse>
    {
        public int Id { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
