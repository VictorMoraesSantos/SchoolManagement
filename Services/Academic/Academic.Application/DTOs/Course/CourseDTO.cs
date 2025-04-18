using Academic.Application.Responses.Department;
using Academic.Application.Responses.Program;

namespace Academic.Application.Responses.Course
{
    public record CourseDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }
        public DepartmentSimpleDTO Departament { get; init; }
        public ProgramSimpleDTO Program { get; init; }

        public CourseDto(int id, DateTime createdAt, DateTime? updatedAt, string code, string name, string description, int credits, int teacherId, DepartmentSimpleDTO departament, ProgramSimpleDTO program)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
            Departament = departament;
            Program = program;
        }
    }
}
