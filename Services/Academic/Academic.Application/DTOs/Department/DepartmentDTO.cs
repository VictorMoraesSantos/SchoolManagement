using Academic.Application.Responses.Course;

namespace Academic.Application.Responses.Department
{
    public class DepartmentDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public IReadOnlyCollection<CourseSimpleDto> Courses { get; init; }
        public IReadOnlyCollection<int> TeachersId { get; init; }

        public DepartmentDto(int id, DateTime createdAt, DateTime? updatedAt, string code, string name, IReadOnlyCollection<CourseSimpleDto> courses, IReadOnlyCollection<int> teachersId)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Code = code;
            Name = name;
            Courses = courses;
            TeachersId = teachersId;
        }
    }
}
