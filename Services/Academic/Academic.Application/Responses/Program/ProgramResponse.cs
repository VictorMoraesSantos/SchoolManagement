﻿using Academic.Application.Responses.Course;

namespace Academic.Application.Responses.Program
{
    public class ProgramResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public IReadOnlyCollection<CourseSimpleResponse> Courses { get; init; }

        public ProgramResponse(int id, DateTime createdAt, DateTime? updatedAt, string code, string name, string description, IReadOnlyCollection<CourseSimpleResponse> courses)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Code = code;
            Name = name;
            Description = description;
            Courses = courses;
        }
    }
}
