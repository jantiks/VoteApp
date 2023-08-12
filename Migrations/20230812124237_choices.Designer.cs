﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeApp.Data;

#nullable disable

namespace RecipesApi.Migrations
{
    [DbContext(typeof(RecipesContext))]
    [Migration("20230812124237_choices")]
    partial class choices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecipeApp.Models.Choice", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("votes")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("choices");
                });

            modelBuilder.Entity("RecipeApp.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
