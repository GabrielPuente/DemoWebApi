using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Infrastructure.Mapping
{
    public static class Mapping
    {
        public static void CreateDefaultProperties(this EntityTypeBuilder builder)
        {
            builder.Property("DateRegister").IsRequired();
            builder.Property("Active").IsRequired();
        }
    }
}