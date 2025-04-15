﻿using Academic.Application.Responses.Course;
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
                course.Code,
                course.Name,
                course.Description,
                course.Credits,
                course.TeacherId,
                course.Department != null ? DepartmentMapper.ToSimpleResponse(course.Department) : null,
                course.Program != null ? ProgramMapper.ToSimpleResponse(course.Program) : null);

            return response;
        }

        public static CourseSimpleResponse ToSimpleResponse(this Course course)
        {
            CourseSimpleResponse response = new CourseSimpleResponse(
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
