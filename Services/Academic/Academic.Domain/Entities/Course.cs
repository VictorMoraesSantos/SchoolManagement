using Core.Domain.Entities;
using Core.Domain.Exceptions;

namespace Academic.Domain.Entities
{
    public class Course : BaseEntity<int>
    {

        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Credits { get; private set; }
        public int TeacherId { get; private set; }
        public IReadOnlyCollection<int> StudentsId => _studentsId.AsReadOnly();

        private readonly List<int> _studentsId = new();

        protected Course() { }

        public Course(string code, string name, string description, int credits, int teacherId)
        {
            SetCourseCode(code);
            SetName(name);
            SetDescription(description);
            SetCredits(credits);
            AssignTeacher(teacherId);
        }

        public Course(string code, string name, string description, int credits)
        {
            SetCourseCode(code);
            SetName(name);
            SetDescription(description);
            SetCredits(credits);
        }

        public void SetCourseCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException("Course code cannot be empty.");

            Code = code.Trim().ToUpper();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Course name cannot be empty.");

            Name = name.ToUpper();
        }

        public void SetDescription(string description)
        {
            Description = description?.ToUpper();
        }

        public void SetCredits(int credits)
        {
            if (credits <= 0)
                throw new DomainException("Credits must be a positive integer.");

            Credits = credits;
        }

        public void AssignTeacher(int teacherId)
        {
            if (teacherId <= 0)
                throw new DomainException("Teacher ID must be valid.");

            TeacherId = teacherId;
        }

        public void AddStudent(int studentId)
        {
            if (studentId <= 0)
                throw new DomainException("Student ID must be valid.");

            if (_studentsId.Contains(studentId))
                throw new DomainException("Student is already enrolled in the course.");

            _studentsId.Add(studentId);
        }

        public void RemoveStudent(int studentId)
        {
            if (!_studentsId.Contains(studentId))
                throw new DomainException("Student is not enrolled in the course.");

            _studentsId.Remove(studentId);
        }
    }
}