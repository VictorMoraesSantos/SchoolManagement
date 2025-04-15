using Academic.Application.Responses.Course;
using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; init; }
        public string Code { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public int Credits { get; init; }
        public int TeacherId { get; init; }

        public UpdateCourseCommand(int id, string code, string name, string description, int credits, int teacherId)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Credits = credits;
            TeacherId = teacherId;
        }
    }
}
