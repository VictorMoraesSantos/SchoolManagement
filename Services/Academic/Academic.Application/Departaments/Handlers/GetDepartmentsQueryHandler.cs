using Academic.Application.Departaments.Queries;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentsQueryHandler : MediatR.IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Department> departments = await _departmentRepository.GetAll(cancellationToken);

            IEnumerable<DepartmentDto> departmentResponses = departments.Select(DepartmentMapper.ToResponse);

            return departmentResponses;
        }
    }
}
