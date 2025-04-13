using Academic.Application.Responses.Course;

namespace Academic.Application.Responses.Department
{
    public class DepartmentSimpleResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public IReadOnlyCollection<int> TeachersId { get; init; }

        public DepartmentSimpleResponse(int id, DateTime createdAt, DateTime? updatedAt, bool isDeleted, string code, string name, IReadOnlyCollection<int> teachersId)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
            Code = code;
            Name = name;
            TeachersId = teachersId;
        }
    }
}
