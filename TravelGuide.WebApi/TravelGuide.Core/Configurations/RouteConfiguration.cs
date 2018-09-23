using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelGuide.Core.Common.Entities;

namespace TravelGuide.Core.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
        }
    }
}
