using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByCodeQueryHandler : IRequestHandler<GetCourseByCodeQuery, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByCodeQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> Handle(GetCourseByCodeQuery query, CancellationToken cancellationToken)
        {
            Course course = await _courseRepository.GetByCode(query.Code, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(query.Code);

            CourseResponse courseResponse = CourseMapper.ToResponse(course);

            return courseResponse;
        }
    }
}
