using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(X => X.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 1 and 365");
            });
        }
    }
}
