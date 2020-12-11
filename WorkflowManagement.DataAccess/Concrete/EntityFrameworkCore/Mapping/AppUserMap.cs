using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.FirstName).HasMaxLength(100);
            builder.Property(I => I.LastName).HasMaxLength(100);

            builder.HasMany(I => I.Jobs).WithOne(A => A.AppUser).HasForeignKey(B => B.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
