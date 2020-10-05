﻿// <auto-generated />
using Class04.EntityFramework.DataModels.CreatedFromDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Class04.EntityFramework.DataModels.Migrations
{
    [DbContext(typeof(NotesExampleContext))]
    [Migration("20201003121857_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Class04.EntityFramework.DataModels.CreatedFromDb.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasMaxLength(30);

                    b.Property<int>("Tag");

                    b.Property<string>("Text")
                        .HasMaxLength(100);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Class04.EntityFramework.DataModels.CreatedFromDb.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Password");

                    b.Property<string>("Username")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Class04.EntityFramework.DataModels.CreatedFromDb.Notes", b =>
                {
                    b.HasOne("Class04.EntityFramework.DataModels.CreatedFromDb.Users", "User")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Notes__UserId__267ABA7A");
                });
#pragma warning restore 612, 618
        }
    }
}
