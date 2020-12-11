using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.Property(a => a.Title).HasMaxLength(200);
            builder.Property(a => a.Description).HasColumnType("ntext");

            builder.HasOne(a => a.Urgency).WithMany(b => b.Jobs).HasForeignKey(a => a.UrgencyId);
        }
    }
}
