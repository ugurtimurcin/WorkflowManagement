using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Title).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Description).HasColumnType("ntext");

            builder.HasOne(a => a.Job).WithMany(a => a.Reports).HasForeignKey(s => s.JobId);
        }
    }
}
