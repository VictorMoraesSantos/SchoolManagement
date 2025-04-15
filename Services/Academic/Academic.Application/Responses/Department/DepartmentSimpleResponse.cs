namespace Academic.Application.Responses.Department
{
    public class DepartmentSimpleResponse
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }

        public DepartmentSimpleResponse(int id, DateTime createdAt, DateTime? updatedAt, string code, string name)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Code = code;
            Name = name;
        }
    }
}
