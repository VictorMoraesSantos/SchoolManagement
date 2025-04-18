using Academic.Application.Departaments.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentByCodeQueryHandler : MediatR.IRequestHandler<GetDepartmentByCodeQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByCodeQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentByCodeQuery query, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetByCode(query.Code, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(query.Code);

            DepartmentDto departmentResponse = DepartmentMapper.ToResponse(department);
            
            return departmentResponse;
        }
    }
}
