using Academic.Application.Departaments.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentByNameQueryHandler : IRequestHandler<GetDepartmentByNameQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByNameQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentByNameQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Department>? departments = await _departmentRepository.GetByName(query.Name, cancellationToken);
            if (departments == null)
                throw new DepartmentNotFoundException(query.Name);

            return departments.Select(d => d.ToResponse()).ToList();
        }
    }
}
