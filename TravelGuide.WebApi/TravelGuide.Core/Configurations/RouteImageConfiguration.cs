using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.Core.Configurations
{
    public class RouteImageConfiguration : IEntityTypeConfiguration<RouteImage>
    {
        public void Configure(EntityTypeBuilder<RouteImage> builder)
        {
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
        }
    }
}
