using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class CourseAlreadyExistsException : BadRequestException
    {
        public CourseAlreadyExistsException(string message) : base(message)
        {
        }

        public CourseAlreadyExistsException(string message, string details) : base(message, details)
        {
        }
    }
}
