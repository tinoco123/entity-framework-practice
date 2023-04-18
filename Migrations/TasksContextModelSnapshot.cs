﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace projectEF.Migrations
{
    [DbContext(typeof(TasksContext))]
    partial class TasksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectEF.Models.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("24d8f5ca-2451-463d-9ead-db339b16af4e"),
                            Nombre = "Universidad",
                            Peso = 50
                        },
                        new
                        {
                            CategoryId = new Guid("7ab81c93-7b17-43b1-9557-ec31ae80fa71"),
                            Descripcion = "Canciones del grupo de alabanza",
                            Nombre = "Grupo de alabanza",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("projectEF.Models.Task", b =>
                {
                    b.Property<Guid>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TaskId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TaskId = new Guid("b35e2399-5842-4199-bf75-26511adde087"),
                            CategoriaId = new Guid("24d8f5ca-2451-463d-9ead-db339b16af4e"),
                            DateCreated = new DateTime(2023, 4, 17, 23, 44, 24, 830, DateTimeKind.Local).AddTicks(1551),
                            Deadline = new DateTime(2023, 4, 20, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            PrioridadTarea = 2,
                            Title = "Estudiar diagramas de clase"
                        },
                        new
                        {
                            TaskId = new Guid("633e026b-489e-4960-bd01-ed5736ab1b6c"),
                            CategoriaId = new Guid("7ab81c93-7b17-43b1-9557-ec31ae80fa71"),
                            DateCreated = new DateTime(2023, 4, 17, 23, 44, 24, 830, DateTimeKind.Local).AddTicks(1568),
                            Deadline = new DateTime(2023, 4, 18, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            PrioridadTarea = 2,
                            Title = "Mandar canciones para el domingo"
                        });
                });

            modelBuilder.Entity("projectEF.Models.Task", b =>
                {
                    b.HasOne("projectEF.Models.Category", "Categoria")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectEF.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
