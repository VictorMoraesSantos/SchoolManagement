using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Commands
{
    public class CreateDepartmentCommand : IRequest<DepartmentDto>
    {
        public string Code { get; init; }
        public string Name { get; init; }

        public CreateDepartmentCommand(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
