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
            StringValidate(code);
            Code = code.Trim().ToUpper();
        }

        public void SetName(string name)
        {
            StringValidate(name);
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

        private void StringValidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"Department {nameof(value)} cannot be empty.");
        }
    }
}
