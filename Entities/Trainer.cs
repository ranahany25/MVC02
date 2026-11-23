using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public class Trainer:GymUser
    {
        public DateTime HierDate { get; set; }
        public Specialties Specialties { get; set; }
        public ICollection<Session> Sessions { get; set; } = null!;
    }
}
