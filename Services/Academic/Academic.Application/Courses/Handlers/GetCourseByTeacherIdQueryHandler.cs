using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByTeacherIdQueryHandler : IRequestHandler<GetCourseByTeacherIdQuery, IEnumerable<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByTeacherIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCourseByTeacherIdQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetByTeacherId(query.Id, cancellationToken);
            if (courses == null)
                throw new CourseNotFoundException(query.Id);

            IEnumerable<CourseDto> coursesResponse = courses.Select(CourseMapper.ToResponse);

            return coursesResponse;
        }
    }
}
