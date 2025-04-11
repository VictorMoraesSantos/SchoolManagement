using MediatR;

namespace Academic.Application.Courses.Commands
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; init; }

        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
