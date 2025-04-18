using Academic.Application.Departaments.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class RemoveTeacherFromDepartmentCommandHandler : IRequestHandler<RemoveTeacherFromDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public RemoveTeacherFromDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(RemoveTeacherFromDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetById(command.DepartmentId, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(command.DepartmentId);

            department.RemoveTeacher(command.TeacherId);
            await _departmentRepository.Update(department, cancellationToken);

            return true;
        }
    }
}
