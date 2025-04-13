﻿using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Queries
{
    public class GetCourseByTeacherIdQuery : IRequest<IEnumerable<CourseResponse>>
    {
        public int Id { get; set; }

        public GetCourseByTeacherIdQuery(int id)
        {
            Id = id;

        }
    }
}
