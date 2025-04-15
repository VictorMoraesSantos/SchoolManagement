using Academic.Application.Responses.Department;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentResponse ToResponse(this Department department)
        {
            DepartmentResponse response = new DepartmentResponse(
                department.Id,
                department.CreatedAt,
                department.UpdatedAt,
                department.Code,
                department.Name,
                department.Courses.Select(c => c.ToSimpleResponse()).ToList(),
                department.TeachersId);

            return response;
        }

        public static DepartmentSimpleResponse ToSimpleResponse(this Department department)
        {
            DepartmentSimpleResponse response = new DepartmentSimpleResponse(
                department.Id,
                department.CreatedAt,
                department.UpdatedAt,
                department.Code,
                department.Name);

            return response;
        }
    }
}
