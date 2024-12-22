
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrasturcture.Configurations;

internal class ToDoItemConfiguartion : IEntityTypeConfiguration<TodoItem>
{


    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
                .HasMaxLength(500)
                .IsRequired();

        builder.Property(t => t.Description)
                .HasMaxLength(1000)
                .IsRequired(false);


        builder.Property(t => t.IsCompleted)
                .IsRequired();

        builder.Property(a => a.CreatedOnUtc)
                .IsRequired();

        builder.Property(a => a.ModifiedOnUtc)
                .IsRequired(false);
    }
}
