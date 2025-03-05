using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RuneDex.DiabloII.Resurrected.Api;
using RuneDex.DiabloII.Resurrected.Infrastructure.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RuneDex.DiabloII.Resurrected.Infrastructure
{
	public class DatabaseContext : DbContext
	{
		private readonly string _schema = "diabloii.resurrected";

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
				.Build(_schema);
			modelBuilder.Entity<ItemTypeEntity>()
				.Build(_schema);
			modelBuilder.Entity<RuneEntity>()
				.Build(_schema);
			modelBuilder.Entity<SkillEntity>()
				.Build(_schema);
			modelBuilder.Entity<StatisticEntity>()
				.Build(_schema);
			modelBuilder.Entity<RuneWordEntity>()
				.Build(_schema);
		}
	}

	internal static class DatabaseContextExtensions
	{
		public static void Build(this EntityTypeBuilder<ClassEntity> builder, string schema)
		{
			builder.ToTable("classes", schema: schema)
				.HasKey(e => e.Id);

			builder.Property(e => e.Id)
				.HasColumnName("id");
			builder.Property(e => e.Name)
				.HasColumnName("name")
				.IsRequired();
		}

		public static void Build(this EntityTypeBuilder<ItemTypeEntity> builder, string schema)
		{
			builder.ToTable("item_types", schema: schema)
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

		public static void Build(this EntityTypeBuilder<RuneEntity> builder, string schema)
		{
			builder.ToTable("runes", schema: schema)
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

		public static void Build(this EntityTypeBuilder<SkillEntity> builder, string schema)
		{
			builder.ToTable("skills", schema: schema)
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

		public static void Build(this EntityTypeBuilder<StatisticEntity> builder, string schema)
		{
			builder.ToTable("statistics", schema: schema)
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

		public static void Build(this EntityTypeBuilder<RuneWordEntity> builder, string schema)
		{
			builder.ToTable("rune_words", schema: schema)
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
														   s.ToTable("rune_words_runes_switch", "diabloii.resurrected");

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
															   s.ToTable("rune_words_item_types_switch", "diabloii.resurrected");
														   });
		}
	}

	[ExcludeFromCodeCoverage]
	public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
	{
		public DatabaseContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
			optionsBuilder.UseNpgsql("Host=mihben.work;Username=postgres;Password=AaZ9SGvNyEjsBuzc;Database=runedex-migration");

			return new DatabaseContext(optionsBuilder.Options);
		}
	}
}
