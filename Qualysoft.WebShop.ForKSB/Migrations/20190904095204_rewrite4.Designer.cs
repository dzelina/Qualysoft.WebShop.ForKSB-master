﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Qualysoft.WebShop.ForKSB.Database;

namespace Qualysoft.WebShop.ForKSB.Migrations
{
    [DbContext(typeof(QualysoftContext))]
    [Migration("20190904095204_rewrite4")]
    partial class rewrite4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Qualysoft.WebShop.ForKSB.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Mobile");

                    b.Property<string>("Password");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Qualysoft.WebShop.ForKSB.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.Property<string>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Qualysoft.WebShop.ForKSB.Models.RelationProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("Visitor");

                    b.HasKey("Id");

                    b.ToTable("Relations");
                });
#pragma warning restore 612, 618
        }
    }
}
