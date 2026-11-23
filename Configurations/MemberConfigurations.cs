using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class MemberConfigurations : GymUserConfigurations<Member>, IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(X => X.CreatedAt)
                .HasColumnName("JoinDate")
                .HasDefaultValueSql("GETDATE()");
            base.Configure(builder);
        }
    }
}
