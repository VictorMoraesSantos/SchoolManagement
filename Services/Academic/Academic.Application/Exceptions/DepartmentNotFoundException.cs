using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class DepartmentNotFoundException : NotFoundException
    {
        public DepartmentNotFoundException(int value) : base("Department", value)
        { }

        public DepartmentNotFoundException(string value) : base("Department", value)
        { }
    }
}
