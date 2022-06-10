using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuron.Common.Data.EF.DataConfigurations;

namespace Auth.Infrastructure.EntityConfigurations
{
    internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.AddSoftDeletebleConfiguration();
        }
    }
}
