using Academic.Application.Responses.Program;
using MediatR;

namespace Academic.Application.Programs.Commands
{
    public class ModifyCourseInProgramCommand : IRequest<bool>
    {
        public int ProgramId { get; init; }
        public int CourseId { get; init; }

        public ModifyCourseInProgramCommand(int programId, int courseId)
        {
            ProgramId = programId;
            CourseId = courseId;
        }
    }
}
