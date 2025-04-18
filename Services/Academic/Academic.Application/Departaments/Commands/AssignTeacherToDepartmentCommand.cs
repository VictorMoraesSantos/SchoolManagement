using MediatR;

namespace Academic.Application.Departaments.Commands
{
    public class AssignTeacherToDepartmentCommand : IRequest<bool>
    {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        
        public AssignTeacherToDepartmentCommand(int departmentId, int teacherId)
        {
            DepartmentId = departmentId;
            TeacherId = teacherId;
        }
    }
}
