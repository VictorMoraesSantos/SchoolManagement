using Academic.Application.Responses;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class CourseMapper
    {
        public static CourseResponse ToResponse(this Course course)
        {
            CourseResponse response = new CourseResponse(
                course.Id,
                course.CreatedAt,
                course.UpdatedAt,
                course.IsDeleted,
                course.Code,
                course.Name,
                course.Description,
                course.Credits,
                course.TeacherId,
                DepartmentMapper.ToResponse(course.Department));

            return response;
        }
    }
}
