using Domain.Core.Helpers;
using Domain.Core.ValueObjects;
using Domain.Projects;
using Domain.Projects.Entities;
using Domain.Projects.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Projects.EntityMappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Project_Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Publication)
                 .IsRequired();

            builder.Property(p => p.Group)
                   .IsRequired()
                   .HasMaxLength(100);
        }

    }
}
