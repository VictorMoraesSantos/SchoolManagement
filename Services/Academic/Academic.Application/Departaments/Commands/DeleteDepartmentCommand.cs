using MediatR;

namespace Academic.Application.Departaments.Commands
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int Id { get; init; }

        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}
