using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class AssignCourseToProgramCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public int ProgramId { get; set; }

        public AssignCourseToProgramCommand(int courseId, int programId)
        {
            CourseId = courseId;
            ProgramId = programId;
        }
    }
}
