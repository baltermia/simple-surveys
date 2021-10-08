using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSurveys.Shared.Models
{
    public class SimpleSurveysContext : DbContext
    {
        public SimpleSurveysContext(DbContextOptions options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<SurveyType> StepTyes { get; set; }
        public DbSet<SurveyType> SurveyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sets the deletion behavior to restricted (data can't be deleted if a forgein key still points to it)
            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Converts a string containing ';' to a list
            ValueConverter converter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));

            // Step
            modelBuilder.Entity<Step>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Radio>("Radio")
                .HasValue<Range>("Range")
                .HasValue<Text>("Text")
                .HasValue<Check>("Check")
                .HasValue<YesNo>("YesNo")
                .HasValue<Date>("Date")
                .HasValue<Number>("Number")
                .HasValue<DropDown>("DropDown");

            modelBuilder.Entity<Step>()
                .Property("Discriminator")
                .HasMaxLength(100);

            modelBuilder.Entity<Radio>().Property(nameof(Radio.Items)).HasConversion(converter);
            modelBuilder.Entity<Check>().Property(nameof(Check.Items)).HasConversion(converter);
            modelBuilder.Entity<DropDown>().Property(nameof(DropDown.Items)).HasConversion(converter);

            // StepResult 

            modelBuilder.Entity<StepResult>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<RadioResult>("RadioResult")
                .HasValue<RangeResult>("RangeResult")
                .HasValue<TextResult>("TextResult")
                .HasValue<CheckResult>("CheckResult")
                .HasValue<YesNoResult>("YesNoResult")
                .HasValue<DateResult>("DateResult")
                .HasValue<NumberResult>("NumberResult")
                .HasValue<DropDownResult>("DropDownResult");

            modelBuilder.Entity<StepResult>()
                .Property("Discriminator")
                .HasMaxLength(100);

            modelBuilder.Entity<CheckResult>().Property(nameof(CheckResult.Items)).HasConversion(converter);
            modelBuilder.Entity<DropDownResult>().Property(nameof(DropDownResult.Items)).HasConversion(converter);
        }
    }
}
