﻿// <auto-generated />
using EmailRules.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SqlServerMigrations.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210715171859_RulesV2")]
    partial class RulesV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmailRules.Models.EmailAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionType")
                        .HasColumnType("int");

                    b.Property<string>("DirectObject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("EmailRules.Models.EmailCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<string>("OnThis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Operator")
                        .HasColumnType("int");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RuleId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("EmailRules.Models.EmailRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequireAllConditions")
                        .HasColumnType("bit");

                    b.Property<bool>("Shared")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("EmailRules.Models.EmailAction", b =>
                {
                    b.HasOne("EmailRules.Models.EmailRule", "Rule")
                        .WithMany("Actions")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("EmailRules.Models.EmailCondition", b =>
                {
                    b.HasOne("EmailRules.Models.EmailRule", "Rule")
                        .WithMany("Conditions")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("EmailRules.Models.EmailRule", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Conditions");
                });
#pragma warning restore 612, 618
        }
    }
}
