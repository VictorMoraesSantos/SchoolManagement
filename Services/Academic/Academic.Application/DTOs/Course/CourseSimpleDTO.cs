namespace Academic.Application.Responses.Course
{
    public class CourseSimpleDto
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }
        
        public CourseSimpleDto(int id, DateTime createdAt, DateTime? updatedAt, string code, string name, string description, int credits, int teacherId)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
        }
    }
}
