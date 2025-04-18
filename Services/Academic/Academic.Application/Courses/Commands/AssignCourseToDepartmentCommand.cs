using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class AssignCourseToDepartmentCommand : IRequest<bool>
    {
        public int CourseId { get; init; }
        public int DepartmentId { get; init; }
        
        public AssignCourseToDepartmentCommand(int courseId, int departmentId)
        {
            CourseId = courseId;
            DepartmentId = departmentId;
        }
    }
}
