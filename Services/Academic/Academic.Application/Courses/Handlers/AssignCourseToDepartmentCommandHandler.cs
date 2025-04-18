using Academic.Application.Courses.Commands;
using Academic.Application.Exceptions;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class AssignCourseToDepartmentCommandHandler : IRequestHandler<AssignCourseToDepartmentCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public AssignCourseToDepartmentCommandHandler(ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<bool> Handle(AssignCourseToDepartmentCommand command, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(command.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(command.CourseId);

            Department? department = await _departmentRepository.GetById(command.DepartmentId, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(command.DepartmentId);

            course.SetDepartment(department);
            await _courseRepository.Update(course, cancellationToken);

            return true;
        }
    }
}
