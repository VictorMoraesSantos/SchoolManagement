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
            Validate(code);
            Code = code.Trim().ToUpper();
        }

        public void SetName(string name)
        {
            Validate(name);
            Name = name.ToUpper();
        }

        public void SetDescription(string description)
        {
            Validate(description);
            Description = description.ToUpper();
        }

        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"Program {nameof(value)} cannot be empty.");
        }
    }
}
