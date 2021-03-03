using GamesLoan.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesLoan.Infra.Data.Configurations
{
    internal class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {            
            builder.Metadata.FindNavigation(nameof(Login.Games)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Login.Friends)).SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasKey(x => x.Id);
            builder.HasIndex(i => i.Email).IsUnique();
            builder.Property(p => p.Password).IsRequired();            
        }        
    }
}

