using Academic.Application.Responses.Course;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class CourseMapper
    {
        public static CourseDto ToResponse(this Course course)
        {
            CourseDto response = new CourseDto(
                course.Id,
                course.CreatedAt,
                course.UpdatedAt,
                course.Code,
                course.Name,
                course.Description,
                course.Credits,
                course.TeacherId,
                course.Department != null ? DepartmentMapper.ToSimpleResponse(course.Department) : null,
                course.Program != null ? ProgramMapper.ToSimpleResponse(course.Program) : null);

            return response;
        }

        public static CourseSimpleDto ToSimpleResponse(this Course course)
        {
            CourseSimpleDto response = new CourseSimpleDto(
                course.Id,
                course.CreatedAt,
                course.UpdatedAt,
                course.Code,
                course.Name,
                course.Description,
                course.Credits,
                course.TeacherId);

            return response;
        }
    }
}
