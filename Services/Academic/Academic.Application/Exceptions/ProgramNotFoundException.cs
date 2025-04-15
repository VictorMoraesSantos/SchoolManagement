using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class ProgramNotFoundException : NotFoundException
    {
        public ProgramNotFoundException(int value) : base("Program", value)
        { }

        public ProgramNotFoundException(string value) : base("Program", value)
        { }
    }
}
