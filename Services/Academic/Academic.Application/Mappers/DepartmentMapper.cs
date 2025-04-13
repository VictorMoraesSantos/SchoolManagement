using Academic.Application.Responses;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentResponse ToResponse(Department department)
        {
            DepartmentResponse response = new DepartmentResponse(
                department.Id,
                department.CreatedAt,
                department.UpdatedAt,
                department.IsDeleted,
                department.Code,
                department.Name,
                department.Courses.Select(c => c.ToResponse()).ToList(),
                department.TeachersId);

            return response;
        }
    }
}
