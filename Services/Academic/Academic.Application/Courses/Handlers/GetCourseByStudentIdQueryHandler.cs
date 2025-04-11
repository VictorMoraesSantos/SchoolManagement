using Academic.Application.Courses.Queries;
using Academic.Application.Exceptions;
using Academic.Application.Mappers;
using Academic.Application.Responses;
using Academic.Domain.Entities;
using Academic.Domain.Repositories;
using MediatR;

namespace Academic.Application.Courses.Handlers
{
    public class GetCourseByStudentIdQueryHandler : IRequestHandler<GetCourseByStudentIdQuery, IEnumerable<CourseResponse>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByStudentIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseResponse>> Handle(GetCourseByStudentIdQuery query, CancellationToken cancellationToken)
        {
            IEnumerable<Course> courses = await _courseRepository.GetByStudentId(query.Id, cancellationToken);
            if (courses == null)
                throw new CourseNotFoundException(query.Id);

            IEnumerable<CourseResponse> coursesResponse = courses.Select(CourseMapper.ToResponse);

            return coursesResponse;
        }
    }
}
