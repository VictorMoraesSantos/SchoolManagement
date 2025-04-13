using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Queries
{
    public class GetDepartmentByCodeQuery : IRequest<DepartmentResponse>
    {
        public string Code { get; set; }

        public GetDepartmentByCodeQuery(string code)
        {
            Code = code;
        }
    }
}
