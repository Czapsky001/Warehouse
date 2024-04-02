﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Warehouse.DatabaseConnector;

#nullable disable

namespace Warehouse.Migrations.Database
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240402155234_TmaRequestConfiguration")]
    partial class TmaRequestConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.Lists.Items.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ContactPerson")
                        .HasColumnType("text");

                    b.Property<int>("ItemGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PriceWithoutVat")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StorageLocation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemGroupId");

                    b.HasIndex("UnitId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Warehouse.Lists.Items.ItemGroup", b =>
                {
                    b.Property<int>("ItemGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ItemGroupId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ItemGroupId");

                    b.ToTable("ItemsGroup");
                });

            modelBuilder.Entity("Warehouse.Lists.Orders.TmaRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PriceWithoutVat")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("UnitId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Warehouse.Lists.Units.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UnitId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Warehouse.Lists.Items.Item", b =>
                {
                    b.HasOne("Warehouse.Lists.Items.ItemGroup", "ItemGroup")
                        .WithMany("Items")
                        .HasForeignKey("ItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Lists.Units.Unit", "Unit")
                        .WithMany("Items")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemGroup");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Warehouse.Lists.Orders.TmaRequest", b =>
                {
                    b.HasOne("Warehouse.Lists.Items.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warehouse.Lists.Units.Unit", "Unit")
                        .WithMany("TmaRequests")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Warehouse.Lists.Items.ItemGroup", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Warehouse.Lists.Units.Unit", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("TmaRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
