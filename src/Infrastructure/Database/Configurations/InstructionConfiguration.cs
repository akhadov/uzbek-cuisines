using Domain.Instructions;
using Domain.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;
internal sealed class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
{
    public void Configure(EntityTypeBuilder<Instruction> builder)
    {
        builder.HasKey(instruction => instruction.Id);

        builder.Property(instruction => instruction.StepNumber)
            .IsRequired();

        builder.ComplexProperty(
            instruction => instruction.Description,
            description => description.Property(d => d.Value).HasColumnName("description"));

        builder.HasOne<Recipe>()
            .WithMany()
            .HasForeignKey(instruction => instruction.RecipeId);
    }
}
