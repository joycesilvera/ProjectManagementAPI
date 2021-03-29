﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcProjectManagement.Models;

namespace ProjectManagementAPI.Migrations
{
    [DbContext(typeof(ProjectManagementDbContext))]
    [Migration("20210329000247_projectsToDB")]
    partial class projectsToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MvcProjectManagement.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamSize")
                        .HasColumnType("int");

                    b.HasKey("ProjectID");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}