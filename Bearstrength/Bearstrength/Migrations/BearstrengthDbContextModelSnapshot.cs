﻿// <auto-generated />
using Bearstrength.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bearstrength.Migrations
{
    [DbContext(typeof(BearstrengthDbContext))]
    partial class BearstrengthDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bearstrength.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Bearstrength.Models.Category", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Bearstrength.Models.Activity", b =>
                {
                    b.HasOne("Bearstrength.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
