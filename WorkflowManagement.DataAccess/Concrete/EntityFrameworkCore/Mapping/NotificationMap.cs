using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();

            builder.Property(s => s.Description).HasColumnType("ntext").IsRequired();

            builder.HasOne(s => s.AppUser).WithMany(a => a.Notifications).HasForeignKey(s => s.AppUserId);
        }
    }
}
