using Academic.Application.Responses.Department;
using MediatR;

namespace Academic.Application.Departaments.Commands
{
    public class UpdateDepartmentCommand : IRequest<DepartmentDto>
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }

        public UpdateDepartmentCommand(int id, string code, string name, int courseId, int teacherId)
        {
            Id = id;
            Code = code;
            Name = name;
            CourseId = courseId;
            TeacherId = teacherId;
        }
    }
}
