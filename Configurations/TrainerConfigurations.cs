using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class TrainerConfigurations : GymUserConfigurations<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.Property(X => X.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            base.Configure(builder);
        }
    }
}
