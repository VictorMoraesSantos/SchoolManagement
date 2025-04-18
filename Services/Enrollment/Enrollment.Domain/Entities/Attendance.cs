using Core.Domain.Entities;
using Enrollment.Domain.Enums;

namespace Enrollment.Domain.Entities
{
    public class Attendance : BaseEntity<int>
    {

        public int StudentId { get; private set; }
        public int CourseId { get; private set; }
        public DateTime DateAttendance { get; private set; } = DateTime.UtcNow;
        public AttendanceStatus Status { get; private set; }

        public Attendance(int studentId, int courseId, DateTime dateAttendance, AttendanceStatus status)
        {
            StudentId = studentId;
            CourseId = courseId;
            DateAttendance = dateAttendance;
            Status = status;
        }

        public void UpdateStatus(AttendanceStatus status)
        {
            Status = status;
            MarkAsUpdated();
        }

        public void MarkPresent()
        {
            Status = AttendanceStatus.Present;
            MarkAsUpdated();
        }
    }
}
