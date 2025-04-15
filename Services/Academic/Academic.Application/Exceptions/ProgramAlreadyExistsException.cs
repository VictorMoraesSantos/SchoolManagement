using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class ProgramAlreadyExistsException : BadRequestException
    {
        public ProgramAlreadyExistsException(string message) : base(message)
        { }

        public ProgramAlreadyExistsException(string message, string details) : base(message, details)
        { }
    }
}
