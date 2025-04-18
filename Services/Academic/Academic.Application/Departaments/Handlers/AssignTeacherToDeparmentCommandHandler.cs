using Academic.Application.Departaments.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class AssignTeacherToDeparmentCommandHandler : IRequestHandler<AssignTeacherToDepartmentCommand, bool>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public AssignTeacherToDeparmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(AssignTeacherToDepartmentCommand command, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetById(command.DepartmentId, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(command.DepartmentId);

            department.AssignTeacher(command.TeacherId);
            await _departmentRepository.Update(department, cancellationToken);

            return true;
        }
    }
}
