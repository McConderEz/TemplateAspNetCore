using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities;
using Template.Domain.Ids;

namespace Template.Infrastructure.Configurations.Write
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("books");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasConversion(
                    id => id.Id,
                    id => BookId.Create(id));
        }
    }
}
