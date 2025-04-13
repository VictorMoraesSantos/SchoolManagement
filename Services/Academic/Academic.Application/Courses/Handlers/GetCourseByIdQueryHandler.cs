using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses.Course;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseResponse> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
        {
            Course course = await _courseRepository.GetById(query.Id, cancellationToken);
            if (course == null)
                throw new CourseNotFoundException(query.Id);

            CourseResponse courseResponse = CourseMapper.ToResponse(course);

            return courseResponse;
        }
    }
}
