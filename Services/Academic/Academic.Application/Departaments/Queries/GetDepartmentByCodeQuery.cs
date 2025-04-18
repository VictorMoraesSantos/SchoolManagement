using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByCodeQuery : IRequest<DepartmentDto>
    {
        public string Code { get; set; }

        public GetDepartmentByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
