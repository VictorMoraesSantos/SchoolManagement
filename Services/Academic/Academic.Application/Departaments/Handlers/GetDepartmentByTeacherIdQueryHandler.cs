using Academic.Application.Departaments.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentByTeacherIdQueryHandler : MediatR.IRequestHandler<GetDepartmentByTeacherIdQuery, DepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByTeacherIdQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponse> Handle(GetDepartmentByTeacherIdQuery query, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetByTeacherId(query.TeacherId, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(query.TeacherId);

            DepartmentResponse departmentResponse = DepartmentMapper.ToResponse(department);

            return departmentResponse;
        }
    }
}
