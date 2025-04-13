using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class DepartmentAlreadyExistsException : BadRequestException
    {
        public DepartmentAlreadyExistsException(string message) : base(message)
        {
        }

        public DepartmentAlreadyExistsException(string message, string details) : base(message, details)
        {
        }
    }
}
