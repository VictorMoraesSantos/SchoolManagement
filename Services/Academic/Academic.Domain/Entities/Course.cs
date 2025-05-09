﻿using Core.Domain.Entities;
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

        public int? DepartmentId { get; private set; }
        public Department Department { get; private set; }
        public int? ProgramId { get; private set; }
        public Program Program { get; private set; }

        public IReadOnlyCollection<int> StudentsId => _studentsId.AsReadOnly();
        private readonly List<int> _studentsId = new();

        protected Course() { }

        public Course(string code, string name, string description, int credits, int teacherId)
        {
            SetCode(code);
            SetName(name);
            SetDescription(description);
            SetCredits(credits);
            AssignTeacher(teacherId);
        }

        public void SetCode(string code)
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
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Course description cannot be empty.");

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
            MarkAsUpdated();
        }

        public void RemoveStudent(int studentId)
        {
            if (!_studentsId.Contains(studentId))
                throw new DomainException("Student is not enrolled in the course.");

            _studentsId.Remove(studentId);
            MarkAsUpdated();
        }

        public void SetDepartment(Department department)
        {
            if (department == null)
                throw new DomainException("Department cannot be null.");

            Department = department;
            DepartmentId = department.Id;
            MarkAsUpdated();
        }

        public void RemoveDepartment()
        {
            Department = null;
            DepartmentId = null;
            MarkAsUpdated();
        }

        public void SetProgram(Program program)
        {
            if (program == null)
                throw new DomainException("Program cannot be null.");

            Program = program;
            ProgramId = program.Id;
            MarkAsUpdated();
        }

        public void RemoveProgram()
        {
            Program = null;
            ProgramId = null;
            MarkAsUpdated();
        }
    }
}