namespace Academic.Application.Responses
{
    public class DepartmentResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public IReadOnlyCollection<CourseResponse> Courses { get; init; }
        public IReadOnlyCollection<int> TeachersId { get; init; }

        public DepartmentResponse(int id, DateTime createdAt, DateTime? updatedAt, bool isDeleted, string code, string name, IReadOnlyCollection<CourseResponse> courses, IReadOnlyCollection<int> teachersId)
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
