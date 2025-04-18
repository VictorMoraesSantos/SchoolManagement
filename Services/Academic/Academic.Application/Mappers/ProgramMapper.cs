using Academic.Application.Responses.Program;
using Academic.Domain.Entities;

namespace Academic.Application.Mappers
{
    public static class ProgramMapper
    {
        public static ProgramDTO ToResponse(this Program program)
        {
            return new ProgramDTO(
                program.Id,
                program.CreatedAt,
                program.UpdatedAt,
                program.Code,
                program.Name,
                program.Description,
                program.Courses.Select(c => c.ToSimpleResponse()).ToList()
            );
        }
        public static ProgramSimpleDTO ToSimpleResponse(this Program program)
        {
            return new ProgramSimpleDTO(
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
