using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.Core.Configurations
{
    public class LocationImageConfiguration : IEntityTypeConfiguration<LocationImage>
    {
        public void Configure(EntityTypeBuilder<LocationImage> builder)
        {
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
        }
    }
}
