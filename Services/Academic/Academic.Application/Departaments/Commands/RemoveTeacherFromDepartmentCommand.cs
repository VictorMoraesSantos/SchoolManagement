using MediatR;

namespace Academic.Application.Departaments.Commands
{
    public class RemoveTeacherFromDepartmentCommand : IRequest<bool>
    {
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }

        public RemoveTeacherFromDepartmentCommand(int departmentId, int teacherId)
        {
            DepartmentId = departmentId;
            TeacherId = teacherId;
        }
    }
}
