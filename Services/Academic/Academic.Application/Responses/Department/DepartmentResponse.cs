using Academic.Application.Responses.Course;

namespace Academic.Application.Responses.Department
{
    public class DepartmentResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public IReadOnlyCollection<CourseSimpleResponse> Courses { get; init; }
        public IReadOnlyCollection<int> TeachersId { get; init; }

        public DepartmentResponse(int id, DateTime createdAt, DateTime? updatedAt, bool isDeleted, string code, string name, IReadOnlyCollection<CourseSimpleResponse> courses, IReadOnlyCollection<int> teachersId)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            Code = code;
            Name = name;
            Courses = courses;
            TeachersId = teachersId;
        }
    }
}
