using Academic.Application.Responses.Department;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto ToResponse(this Department department)
        {
            DepartmentDto response = new DepartmentDto(
                department.Id,
                department.CreatedAt,
                department.UpdatedAt,
                department.Code,
                department.Name,
                department.Courses.Select(c => c.ToSimpleResponse()).ToList(),
                department.TeachersId);

            return response;
        }

        public static DepartmentSimpleDTO ToSimpleResponse(this Department department)
        {
            DepartmentSimpleDTO response = new DepartmentSimpleDTO(
                department.Id,
                department.CreatedAt,
                department.UpdatedAt,
                department.Code,
                department.Name);

            return response;
        }
    }
}
