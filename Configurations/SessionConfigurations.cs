using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(X => X.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(X => X.Trainer)
                .WithMany(X => X.Sessions)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(T =>
            {
                T.HasCheckConstraint("SessionCapacityConstraint", "Capacity between 1 and 25");
                T.HasCheckConstraint("SessionEndDateAfterStartDate", "EndDate>StartDate");
            });
        }
    }
}
