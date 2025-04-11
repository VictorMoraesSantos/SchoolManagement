using BuildingBlocks.Exceptions;

namespace Academic.Application.Exceptions
{
    public class CourseNotFoundException : NotFoundException
    {
        public CourseNotFoundException(int value) : base("Course", value)
        { }

        public CourseNotFoundException(string value) : base("Course", value)
        { }
    }
}
