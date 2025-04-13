using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByCreditsQueryHandler : IRequestHandler<GetCourseByCreditsQuery, IEnumerable<CourseResponse>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByCreditsQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseResponse>> Handle(GetCourseByCreditsQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetByCredits(query.Credits, cancellationToken);
            if (courses == null)
                throw new CourseNotFoundException(query.Credits);

            IEnumerable<CourseResponse> coursesResponse = courses.Select(CourseMapper.ToResponse);

            return coursesResponse;
        }
    }
}
