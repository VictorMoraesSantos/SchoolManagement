using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class CreateCourseCommand : IRequest<CourseResponse>
    {
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }
        public int? DepartmentId { get; init; }
        public int? ProgramId { get; init; }

        public CreateCourseCommand(string code, string name, string description, int credits, int teacherId, int? departmentId, int? programId)
        {
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
            DepartmentId = departmentId;
            ProgramId = programId;
        }
    }
}
