using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, IEnumerable<CourseResponse>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByNameQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseResponse>> Handle(GetCourseByNameQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetByName(query.Name, cancellationToken);
            if (courses == null)
                throw new CourseNotFoundException(query.Name);

            IEnumerable<CourseResponse> coursesResponse = courses.Select(CourseMapper.ToResponse);

            return coursesResponse;
        }
    }
}
