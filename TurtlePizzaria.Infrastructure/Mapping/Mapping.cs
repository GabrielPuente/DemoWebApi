using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TurtlePizzaria.Infrastructure.Mapping
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