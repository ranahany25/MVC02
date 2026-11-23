using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public abstract class GymUser:BaseEntity
    {
        public string Name { get; set; }= null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; } = null!;
    }
}
