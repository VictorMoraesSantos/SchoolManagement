using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class RemoveDepartmentFromCourseCommand : IRequest<bool>
    {
        public int CourseId { get; init; }
        public int DepartmentId { get; init; }
        
        public RemoveDepartmentFromCourseCommand(int courseId, int departmentId)
        {
            CourseId = courseId;
            DepartmentId = departmentId;
        }
    }
}
