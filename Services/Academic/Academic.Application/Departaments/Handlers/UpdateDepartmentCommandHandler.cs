using Academic.Application.Departaments.Commands;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;

        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
        {
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<DepartmentDto> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.CourseId);

            Department? department = await _departmentRepository.GetById(command.Id, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(command.Id);

            department.SetName(command.Name);
            department.SetCode(command.Code);
            department.AssignTeacher(command.TeacherId);

            await _departmentRepository.Update(department, cancellationToken);

            return DepartmentMapper.ToResponse(department);
        }
    }
}
