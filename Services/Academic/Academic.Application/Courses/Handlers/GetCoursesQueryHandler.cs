using Academic.Application.Courses.Queries;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAll(cancellationToken);
            IEnumerable<CourseDto> coursesResponse = courses.Select(CourseMapper.ToResponse);
            return coursesResponse;
        }
    }
}
