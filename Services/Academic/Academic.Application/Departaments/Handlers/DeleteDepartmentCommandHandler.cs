using Academic.Application.Departaments.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetById(command.Id, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(command.Id);

            department.MarkAsDeleted();
            await _departmentRepository.Update(department, cancellationToken);

            return true;
        }
    }
}
