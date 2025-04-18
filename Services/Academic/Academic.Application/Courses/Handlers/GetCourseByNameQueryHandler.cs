using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, IEnumerable<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByNameQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCourseByNameQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetByName(query.Name, cancellationToken);
            if (courses == null)
                throw new CourseNotFoundException(query.Name);

            IEnumerable<CourseDto> coursesResponse = courses.Select(CourseMapper.ToResponse);

            return coursesResponse;
        }
    }
}
