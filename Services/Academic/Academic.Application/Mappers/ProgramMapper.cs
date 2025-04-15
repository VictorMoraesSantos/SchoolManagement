using Academic.Application.Responses.Program;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class ProgramMapper
    {
        public static ProgramResponse ToResponse(this Program program)
        {
            return new ProgramResponse(
                program.Id,
                program.CreatedAt,
                program.UpdatedAt,
                program.Code,
                program.Name,
                program.Description,
                program.Courses.Select(c => c.ToSimpleResponse()).ToList()
            );
        }
        public static ProgramSimpleResponse ToSimpleResponse(this Program program)
        {
            return new ProgramSimpleResponse(
                program.Id,
                program.CreatedAt,
                program.UpdatedAt,
                program.Code,
                program.Name,
                program.Description
            );
        }
    }
}
