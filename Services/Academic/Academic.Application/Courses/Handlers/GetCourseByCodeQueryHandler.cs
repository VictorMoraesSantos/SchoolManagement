using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByCodeQueryHandler : IRequestHandler<GetCourseByCodeQuery, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByCodeQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> Handle(GetCourseByCodeQuery query, CancellationToken cancellationToken)
        {
            Course course = await _courseRepository.GetByCode(query.Code, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(query.Code);

            CourseDto courseResponse = CourseMapper.ToResponse(course);

            return courseResponse;
        }
    }
}
