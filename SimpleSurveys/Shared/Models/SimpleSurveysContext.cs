using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;

namespace SimpleSurveys.Shared.Models
{
    public class SimpleSurveysContext : DbContext
    {
        public SimpleSurveysContext(DbContextOptions options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Step> Steps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sets the deletion behavior to restricted (data can't be deleted if a forgein key still points to it)
            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
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
        }
    }
}
