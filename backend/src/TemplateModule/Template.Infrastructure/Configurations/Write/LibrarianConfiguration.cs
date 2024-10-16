using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Aggregate;
using Template.Domain.Ids;

namespace Template.Infrastructure.Configurations.Write
{
    internal class LibrarianConfiguration : IEntityTypeConfiguration<Librarian>
    {
        public void Configure(EntityTypeBuilder<Librarian> builder)
        {
            builder.ToTable("librarians");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Id,
                    id => LibrarianId.Create(id));

            builder.HasMany(l => l.Books)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
