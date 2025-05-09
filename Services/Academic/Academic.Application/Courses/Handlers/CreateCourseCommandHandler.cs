﻿using Academic.Application.Courses.Commands;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> Handle(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            Course? courseExists = await _courseRepository.GetByCode(command.Code, cancellationToken);
            if (courseExists != null)
                throw new CourseAlreadyExistsException(command.Code, $"Já existe um curso com o código '{command.Code}'.");

            Course course = new Course(command.Code, command.Name, command.Description, command.Credits, command.TeacherId);
            await _courseRepository.Create(course, cancellationToken);

            return CourseMapper.ToResponse(course);
        }
    }
}
