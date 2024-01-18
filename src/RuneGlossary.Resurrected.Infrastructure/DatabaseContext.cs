using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuneGlossary.Resurrected.Api;
using RuneGlossary.Resurrected.Infrastructure.Entities;

namespace RuneGlossary.Resurrected.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<ItemTypeEntity> ItemTypes { get; set; }
        public DbSet<RuneEntity> Runes { get; set; }
        public DbSet<RuneWordEntity> RuneWords { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassEntity>()
                .Build();
            modelBuilder.Entity<ItemTypeEntity>()
                .Build();
            modelBuilder.Entity<RuneEntity>()
                .Build();
            modelBuilder.Entity<SkillEntity>()
                .Build();
            modelBuilder.Entity<StatisticEntity>()
                .Build();
            modelBuilder.Entity<RuneWordEntity>()
                .Build();
        }
    }

    internal static class DatabaseContextExtensions
    {
        public static void Build(this EntityTypeBuilder<ClassEntity> builder)
        {
            builder.ToTable("classes", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
        }

        public static void Build(this EntityTypeBuilder<ItemTypeEntity> builder)
        {
            builder.ToTable("item_types", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Class)
                .HasColumnName("class")
                .IsRequired()
                .HasConversion(new EnumToStringConverter<ItemClass>());
        }

        public static void Build(this EntityTypeBuilder<RuneEntity> builder)
        {
            builder.ToTable("runes", "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Level)
                .HasColumnName("level");
            builder.Property(e => e.InWeapon)
                .HasColumnName("in_weapon")
                .IsRequired();
            builder.Property(e => e.InHelmet)
                .HasColumnName("in_helmet")
                .IsRequired();
            builder.Property(e => e.InBodyArmor)
                .HasColumnName("in_body_armor")
                .IsRequired();
            builder.Property(e => e.InShield)
                .HasColumnName("in_shield")
                .IsRequired();
        }

        public static void Build(this EntityTypeBuilder<SkillEntity> builder)
        {
            builder.ToTable("skills", schema: "resurrected")
                .HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id");
            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired();
            builder.Property(e => e.Url)
                .HasColumnName("url")
                .IsRequired();
        }

        public static void Build(this EntityTypeBuilder<StatisticEntity> builder)
        {
            builder.ToTable("statistics", schema: "resurrected")
                .HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            builder.Property(s => s.Description)
                .HasColumnName("description")
                .IsRequired();
            builder.HasOne(s => s.Skill)
                .WithMany()
                .HasForeignKey("skill_id")
                .HasConstraintName("FK_statistics_skill_id");
        }

        public static void Build(this EntityTypeBuilder<RuneWordEntity> builder)
        {
            builder.ToTable("rune_words", schema: "resurrected")
                .HasKey(rw => rw.Id);

            builder.Property(rw => rw.Id)
                .HasColumnName("id");
            builder.Property(rw => rw.Name)
                .HasColumnName("name")
                .IsRequired();
            builder.Property(rw => rw.Level)
                .HasColumnName("level")
                .IsRequired();
            builder.Property(rw => rw.Url)
                .HasColumnName("url")
                .IsRequired();
            builder.HasMany(rw => rw.Statistics)
                .WithOne()
                .HasForeignKey("rune_word_id")
                .HasConstraintName("FK_rune_word_statistics")
                .IsRequired();
            builder.HasMany(rw => rw.Runes)
                .WithMany(r => r.RuneWords)
                .UsingEntity<RuneRuneWordSwitchEntity>(s => s.HasOne(rrws => rrws.Rune)
                                                                                .WithMany(r => r.RuneWordSwitch)
                                                                                .HasConstraintName("FK_runes_rune_words")
                                                                                .HasForeignKey("rune_id")
                                                                                .IsRequired()
                                                                                .OnDelete(DeleteBehavior.Cascade),
                                                       s => s.HasOne(rrws => rrws.RuneWord)
                                                                            .WithMany(r => r.RuneSwitch)
                                                                            .HasConstraintName("FK_rune_words_runes")
                                                                            .HasForeignKey("rune_word_id")
                                                                            .IsRequired()
                                                                            .OnDelete(DeleteBehavior.Cascade),
                                                       s =>
                                                       {
                                                           s.ToTable("rune_words_runes_switch", "resurrected");

                                                           s.Property(rrws => rrws.Order)
                                                                    .HasColumnName("order")
                                                                    .IsRequired();
                                                       });

            builder.HasMany(rw => rw.ItemTypes)
                .WithMany(it => it.RuneWords)
                .UsingEntity<RuneWordItemTypeSwitchEntity>(s => s.HasOne(rwits => rwits.ItemType)
                                                                                    .WithMany(it => it.ItemTypeSwitch)
                                                                                    .HasConstraintName("FK_item_types_rune_words")
                                                                                    .HasForeignKey("item_type_id")
                                                                                    .IsRequired()
                                                                                    .OnDelete(DeleteBehavior.Cascade),
                                                           s => s.HasOne(rwits => rwits.RuneWord)
                                                                    .WithMany(rw => rw.ItemTypeSwitch)
                                                                    .HasConstraintName("FK_rune_words_item_types")
                                                                    .HasForeignKey("rune_word_id")
                                                                    .IsRequired()
                                                                    .OnDelete(DeleteBehavior.Cascade),
                                                           s =>
                                                           {
                                                               s.ToTable("rune_words_item_types_switch", "resurrected");
                                                           });
        }
    }

    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql("Host=mihben.work;Username=postgres;Password=AaZ9SGvNyEjsBuzc;Database=rune_glossary-migration");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
