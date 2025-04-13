using Academic.Application.Responses;
using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<CourseResponse>
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }
        public int DepartmentId { get; init; }
        public int StudentId { get; init; }


        public UpdateCourseCommand(int id, string code, string name, string description, int credits, int teacherId, int departmentId, int studentId)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
            DepartmentId = departmentId;
            StudentId = studentId;
        }
    }
}
