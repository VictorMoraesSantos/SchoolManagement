using Core.Domain.Entities;
using Core.Domain.Exceptions;

namespace Academic.Domain.Entities
{
    public class Program : BaseEntity<int>
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();
        private readonly List<Course> _courses = new();

        protected Program() { }

        public Program(string code, string name, string description)
        {
            SetCode(code);
            SetName(name);
            SetDescription(description);
        }

        public void SetCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException("Program code cannot be empty.");

            Code = code.Trim().ToUpper();
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Program name cannot be empty.");

            Name = name.ToUpper();
        }

        public void SetDescription(string description)
        {
            Description = description?.ToUpper();
        }

        public void AddCourse(Course course)
        {
            if (course == null)
                throw new DomainException("Course cannot be null.");

            if (_courses.Any(c => c.Code == course.Code))
                throw new DomainException("Course already exists in this program.");

            _courses.Add(course);
            MarkAsUpdated();

            course.SetProgram(this);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
                throw new DomainException("Course cannot be null.");

            if (!_courses.Remove(course))
                throw new DomainException("Course not found in this program.");
         
            MarkAsUpdated();
        }
    }
}
