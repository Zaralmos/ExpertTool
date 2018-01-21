﻿// <auto-generated />
using ExpertTool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ExpertTool.Migrations
{
    [DbContext(typeof(EtContext))]
    partial class EtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpertTool.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdminId");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ExpertTool.Models.Conclusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<byte>("Depression");

                    b.Property<int>("ExpertId");

                    b.Property<byte>("Hypochondriasis");

                    b.Property<byte>("Hypomania");

                    b.Property<byte>("Hysteria");

                    b.Property<byte>("MaculinityFeminity");

                    b.Property<byte>("Paranoia");

                    b.Property<int>("PersonId");

                    b.Property<byte>("Psychasthenia");

                    b.Property<byte>("PsychopathicDeviate");

                    b.Property<byte>("Schizophrenia");

                    b.Property<byte>("SocialInteroversion");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("PersonId");

                    b.ToTable("Conclusions");
                });

            modelBuilder.Entity("ExpertTool.Models.Expert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdminId");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Experts");
                });

            modelBuilder.Entity("ExpertTool.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminId");

                    b.Property<string>("Biography");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Career");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<string>("Position");

                    b.Property<string>("Publish");

                    b.Property<DateTime>("Published");

                    b.Property<string>("Quotations");

                    b.Property<string>("ReligiousViews");

                    b.Property<string>("ShortInfo")
                        .HasMaxLength(1000);

                    b.Property<string>("SocialActivity");

                    b.Property<string>("Video");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ExpertTool.Models.Admin", b =>
                {
                    b.HasOne("ExpertTool.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("ExpertTool.Models.Conclusion", b =>
                {
                    b.HasOne("ExpertTool.Models.Expert", "Expert")
                        .WithMany("Conclusions")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExpertTool.Models.Person", "Person")
                        .WithMany("Conclusions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ExpertTool.Models.Expert", b =>
                {
                    b.HasOne("ExpertTool.Models.Admin", "Admin")
                        .WithMany("Experts")
                        .HasForeignKey("AdminId");
                });

            modelBuilder.Entity("ExpertTool.Models.Person", b =>
                {
                    b.HasOne("ExpertTool.Models.Admin", "Admin")
                        .WithMany("People")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
