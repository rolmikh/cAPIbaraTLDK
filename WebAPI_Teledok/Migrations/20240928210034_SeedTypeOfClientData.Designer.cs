﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Teledok.Class;

#nullable disable

namespace WebAPI_Teledok.Migrations
{
    [DbContext(typeof(Teledok_Context))]
    [Migration("20240928210034_SeedTypeOfClientData")]
    partial class SeedTypeOfClientData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_Teledok.Class.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Client");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<DateTime>("DateOfAdditionClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Date_Of_Addition_Client")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateOfUpdateClient")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_Of_Update_Client");

                    b.Property<string>("INNClient")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("INN_Client");

                    b.Property<string>("NameClient")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name_Client");

                    b.Property<int>("TypeOfClientID")
                        .HasColumnType("int")
                        .HasColumnName("Type_Of_Client_ID");

                    b.HasKey("IdClient");

                    b.HasIndex("TypeOfClientID");

                    b.HasIndex(new[] { "INNClient" }, "UQ_INN_Client")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.Founder", b =>
                {
                    b.Property<int>("IdFounder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Founder");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFounder"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int")
                        .HasColumnName("Client_ID");

                    b.Property<DateTime>("DateOfAdditionFounder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("Date_Of_Addition_Founder")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateOfUpdateFounder")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_Of_Update_Founder");

                    b.Property<string>("INNFounder")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("INN_Founder");

                    b.Property<string>("MiddleNameFounder")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("MiddleName_Founder");

                    b.Property<string>("NameFounder")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Name_Founder");

                    b.Property<string>("SurnameFounder")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Surname_Founder");

                    b.HasKey("IdFounder");

                    b.HasIndex("ClientID");

                    b.HasIndex(new[] { "INNFounder" }, "UQ_INN_Founder")
                        .IsUnique();

                    b.ToTable("Founder", (string)null);
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.TypeOfClient", b =>
                {
                    b.Property<int>("IdTypeOfClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_Type_Of_Client");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTypeOfClient"));

                    b.Property<string>("NameTypeOfClient")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Name_Type_Of_Client");

                    b.HasKey("IdTypeOfClient");

                    b.HasIndex(new[] { "NameTypeOfClient" }, "UQ_Name_Type_Of_Client")
                        .IsUnique();

                    b.ToTable("Type_Of_Client", (string)null);

                    b.HasData(
                        new
                        {
                            IdTypeOfClient = 1,
                            NameTypeOfClient = "Юридическое лицо"
                        },
                        new
                        {
                            IdTypeOfClient = 2,
                            NameTypeOfClient = "Индивидуальный предприниматель"
                        });
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.Client", b =>
                {
                    b.HasOne("WebAPI_Teledok.Class.TypeOfClient", "TypeOfClient")
                        .WithMany("Clients")
                        .HasForeignKey("TypeOfClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Type_Of_Client");

                    b.Navigation("TypeOfClient");
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.Founder", b =>
                {
                    b.HasOne("WebAPI_Teledok.Class.Client", "Client")
                        .WithMany("Founders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Client");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.Client", b =>
                {
                    b.Navigation("Founders");
                });

            modelBuilder.Entity("WebAPI_Teledok.Class.TypeOfClient", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
