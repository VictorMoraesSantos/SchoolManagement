using Core.Domain.Entities;
using Core.Domain.Exceptions;

namespace Academic.Domain.Entities
{
    public class Department : BaseEntity<int>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();
        private readonly List<Course> _courses = new();
        public IReadOnlyCollection<int> TeachersId => _teachersId.AsReadOnly();
        private readonly List<int> _teachersId = new();

        protected Department() { }

        public Department(string code, string name)
        {
            SetCode(code);
            SetName(name);
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException("Department code cannot be empty.");

            Code = code.Trim().ToUpper();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Department name cannot be empty.");

            Name = name.ToUpper();
        }

        public void AssignTeacher(int teacherId)
        {
            if (teacherId <= 0)
                throw new DomainException("Teacher ID must be valid.");

            if (_teachersId.Contains(teacherId))
                throw new DomainException("Teacher is already assigned to this department.");

            _teachersId.Add(teacherId);
        }

        public void RemoveTeacher(int teacherId)
        {
            if (!_teachersId.Contains(teacherId))
                throw new DomainException("Teacher is not assigned to this department.");

            _teachersId.Remove(teacherId);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
                throw new DomainException("Course cannot be null.");

            if (_courses.Any(c => c.Code == course.Code.Trim().ToUpper()))
                throw new DomainException("A course with the same code is already assigned to this department.");

            _courses.Add(course);
            MarkAsUpdated();

            course.SetDepartment(this);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
                throw new DomainException("Course cannot be null.");

            if (!_courses.Remove(course))
                throw new DomainException("Course not found in this program.");
        }
    }
}
