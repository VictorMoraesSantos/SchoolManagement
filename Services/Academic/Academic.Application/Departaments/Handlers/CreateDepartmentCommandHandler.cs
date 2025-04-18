using Academic.Application.Departaments.Commands;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class CreateDepartmentCommandHandler : MediatR.IRequestHandler<CreateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department? departmentExsists = await _departmentRepository.GetByCode(command.Code, cancellationToken);
            if (departmentExsists != null)
                throw new DepartmentAlreadyExistsException($"Já existe um departamento com o código '{command.Code}'.");

            Department department = new Department(command.Code, command.Name);

            await _departmentRepository.Create(department, cancellationToken);

            return DepartmentMapper.ToResponse(department);
        }
    }
}
