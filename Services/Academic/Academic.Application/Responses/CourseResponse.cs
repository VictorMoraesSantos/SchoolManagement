﻿namespace Academic.Application.Responses
{
    public record CourseResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }
        public DepartmentResponse Departament { get; init; }

        public CourseResponse(int id, DateTime createdAt, DateTime? updatedAt, bool isDeleted, string code, string name, string description, int credits, int teacherId, DepartmentResponse departament)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
            Departament = departament;
        }
    }
}
