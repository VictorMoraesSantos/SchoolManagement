using Academic.Application.Departaments.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentByCourseQueryHandler : MediatR.IRequestHandler<GetDepartmentByCourseQuery, DepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICourseRepository _courseRepository;

        public GetDepartmentByCourseQueryHandler(IDepartmentRepository departmentRepository, ICourseRepository courseRepository)
        {
            _departmentRepository = departmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<DepartmentResponse> Handle(GetDepartmentByCourseQuery query, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetById(query.CourseId, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(query.CourseId);

            Department? department = await _departmentRepository.GetByCourse(course, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(course.Id);

            DepartmentResponse departmentResponse = DepartmentMapper.ToResponse(department);

            return departmentResponse;
        }
    }
}
