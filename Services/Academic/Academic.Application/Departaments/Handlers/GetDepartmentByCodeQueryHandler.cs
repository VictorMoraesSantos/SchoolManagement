using Academic.Application.Departaments.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Department;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Departaments.Handlers
{
    public class GetDepartmentByCodeQueryHandler : MediatR.IRequestHandler<GetDepartmentByCodeQuery, DepartmentResponse>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetDepartmentByCodeQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentResponse> Handle(GetDepartmentByCodeQuery query, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetByCode(query.Code, cancellationToken);
            if (department == null)
                throw new DepartmentNotFoundException(query.Code);

            DepartmentResponse departmentResponse = DepartmentMapper.ToResponse(department);
            
            return departmentResponse;
        }
    }
}
