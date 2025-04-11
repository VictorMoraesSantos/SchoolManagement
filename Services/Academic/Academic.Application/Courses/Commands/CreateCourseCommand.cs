﻿using Academic.Application.Responses;
using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class CreateCourseCommand : IRequest<CourseResponse>
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }

        public CreateCourseCommand(string code, string name, string description, int credits, int teacherId)
        {
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
        }
    }
}
