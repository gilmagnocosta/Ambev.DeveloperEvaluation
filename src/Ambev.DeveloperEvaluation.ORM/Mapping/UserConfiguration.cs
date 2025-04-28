using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Phone).HasMaxLength(20);

        builder.OwnsOne(u => u.Name)
            .Property(p => p.Firstname)
            .HasColumnName("Firstname")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(u => u.Name)
            .Property(p => p.Lastname)
            .HasColumnName("Lastname")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(u => u.Address)
            .Property(p => p.City)
            .HasColumnName("AddressCity")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.OwnsOne(u => u.Address)
            .Property(p => p.Street)
            .HasColumnName("AddressStreet")
            .HasMaxLength(50)
            .IsRequired();

        builder.OwnsOne(u => u.Address)
            .Property(p => p.Number)
            .HasColumnName("AddressNumber")
            .HasMaxLength(20)
            .IsRequired();

        builder.OwnsOne(u => u.Address)
            .Property(p => p.ZipCode)
            .HasColumnName("AddressZipcode")
            .HasMaxLength(20)
            .IsRequired();

        builder.OwnsOne(u => u.Address, address =>
        {
            address.OwnsOne(x => x.Geolocation,
                geolocation =>
                {
                    geolocation.Property(p => p.Lat)
                    .HasColumnName("AddressGeoLat").
                    HasMaxLength(50)
                    .IsRequired(false);
                });

            address.OwnsOne(x => x.Geolocation,
                geolocation =>
                {
                    geolocation.Property(p => p.Long)
                    .HasColumnName("AddressGeoLong").
                    HasMaxLength(50)
                    .IsRequired(false);
                });
        });

        builder.Property(u => u.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(20);

    }
}
