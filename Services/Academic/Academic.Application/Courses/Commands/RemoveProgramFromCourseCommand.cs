using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class RemoveProgramFromCourseCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public int ProgramId { get; set; }
        
        public RemoveProgramFromCourseCommand(int courseId, int programId)
        {
            CourseId = courseId;
            ProgramId = programId;
        }
    }
}
