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
            builder.ToTable("Project");

            builder.HasKey(p => new { p.EmployerEmail, p.ProjectName });

            builder.Property(p => p.ProjectDescription);

            builder.Property(p => p.MaximumAmountForBenefits);

            builder.Property(p => p.MaximumBenefitAmount);

            builder.Property(p => p.PaymentInterval);
        }

    }
}
