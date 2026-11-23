using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(X => X.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.HasOne(m => m.Plan)
                .WithMany(p => p.PlanSubscriptions)
                .HasForeignKey(m => m.PlanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
