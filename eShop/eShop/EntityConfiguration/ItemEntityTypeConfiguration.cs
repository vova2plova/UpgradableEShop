using eShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.EntityConfiguration
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .Property("Title")
                .HasMaxLength(200);

            builder
                .Property("Description")
                .HasMaxLength(500);

            builder
                .Property("Thumbnail")
                .HasMaxLength(500);
        }
    }
}
