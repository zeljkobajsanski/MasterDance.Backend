﻿// <auto-generated />
using System;
using MasterDance.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MasterDance.Persistence.Migrations
{
    [DbContext(typeof(MasterDanceDbContext))]
    [Migration("20190204074016_Users")]
    partial class Users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MasterDance.Domain.Entities.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("date");

                    b.Property<int>("MemberId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TypeId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MemberId");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberImages");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.MemberGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Membership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<int>("MemberId");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("MembershipId");

                    b.HasKey("Id");

                    b.HasIndex("MembershipId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("JMBG")
                        .HasMaxLength(13);

                    b.Property<string>("LastName")
                        .HasMaxLength(128);

                    b.Property<string>("MemberType")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("MemberType").HasValue("Person");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Prize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasMaxLength(255);

                    b.Property<string>("Choreography")
                        .HasMaxLength(255);

                    b.Property<int>("CompetitionId");

                    b.Property<int>("MemberId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("MemberId");

                    b.ToTable("Prizes");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.TrainingType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasMaxLength(32);

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("TrainingTypes");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("IMEI")
                        .HasMaxLength(255);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Role")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Coach", b =>
                {
                    b.HasBaseType("MasterDance.Domain.Entities.Person");

                    b.HasDiscriminator().HasValue("Coach");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Member", b =>
                {
                    b.HasBaseType("MasterDance.Domain.Entities.Person");

                    b.Property<bool>("Dance")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<bool>("Gymnastics");

                    b.Property<string>("Image");

                    b.Property<DateTime?>("JoinedDate")
                        .HasColumnType("date");

                    b.Property<int?>("MemberGroupId");

                    b.HasIndex("MemberGroupId");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Document", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.Member", "Member")
                        .WithMany("Documents")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MasterDance.Domain.Entities.DocumentType", "Type")
                        .WithMany("Documents")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MasterDance.Domain.ValueObjects.Blob", "Content", b1 =>
                        {
                            b1.Property<int>("DocumentId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Content")
                                .HasColumnName("Content");

                            b1.Property<string>("ContentType")
                                .HasColumnName("ContentType")
                                .HasMaxLength(255);

                            b1.Property<string>("FileName")
                                .HasColumnName("FileName")
                                .HasMaxLength(255);

                            b1.HasKey("DocumentId");

                            b1.ToTable("Documents");

                            b1.HasOne("MasterDance.Domain.Entities.Document")
                                .WithOne("Content")
                                .HasForeignKey("MasterDance.Domain.ValueObjects.Blob", "DocumentId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Image", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.Member", "Member")
                        .WithMany("Images")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MasterDance.Domain.ValueObjects.Blob", "Blob", b1 =>
                        {
                            b1.Property<int>("ImageId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Content")
                                .HasColumnName("Content");

                            b1.Property<string>("ContentType")
                                .ValueGeneratedOnAdd()
                                .HasColumnName("ContentType")
                                .HasDefaultValue("image/png");

                            b1.Property<string>("FileName")
                                .HasColumnName("FileName");

                            b1.HasKey("ImageId");

                            b1.ToTable("MemberImages");

                            b1.HasOne("MasterDance.Domain.Entities.Image")
                                .WithOne("Blob")
                                .HasForeignKey("MasterDance.Domain.ValueObjects.Blob", "ImageId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Membership", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Payment", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.Membership", "Membership")
                        .WithMany("Payments")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Person", b =>
                {
                    b.OwnsOne("MasterDance.Domain.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .HasColumnName("Address")
                                .HasMaxLength(255);

                            b1.Property<string>("Email")
                                .HasColumnName("Email")
                                .HasMaxLength(255);

                            b1.Property<string>("Phone")
                                .HasColumnName("Phone")
                                .HasMaxLength(255);

                            b1.HasKey("PersonId");

                            b1.ToTable("Persons");

                            b1.HasOne("MasterDance.Domain.Entities.Person")
                                .WithOne("Contact")
                                .HasForeignKey("MasterDance.Domain.ValueObjects.Contact", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Prize", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MasterDance.Domain.Entities.Member", "Member")
                        .WithMany("Prizes")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MasterDance.Domain.Entities.Member", b =>
                {
                    b.HasOne("MasterDance.Domain.Entities.MemberGroup", "MemberGroup")
                        .WithMany("Members")
                        .HasForeignKey("MemberGroupId");

                    b.OwnsOne("MasterDance.Domain.ValueObjects.Parent", "Father", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .HasColumnName("Father")
                                .HasMaxLength(255);

                            b1.Property<string>("Phone")
                                .HasColumnName("FatherPhone")
                                .HasMaxLength(255);

                            b1.HasKey("MemberId");

                            b1.ToTable("Persons");

                            b1.HasOne("MasterDance.Domain.Entities.Member")
                                .WithOne("Father")
                                .HasForeignKey("MasterDance.Domain.ValueObjects.Parent", "MemberId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("MasterDance.Domain.ValueObjects.Parent", "Mother", b1 =>
                        {
                            b1.Property<int>("MemberId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .HasColumnName("Mother")
                                .HasMaxLength(255);

                            b1.Property<string>("Phone")
                                .HasColumnName("MotherPhone")
                                .HasMaxLength(255);

                            b1.HasKey("MemberId");

                            b1.ToTable("Persons");

                            b1.HasOne("MasterDance.Domain.Entities.Member")
                                .WithOne("Mother")
                                .HasForeignKey("MasterDance.Domain.ValueObjects.Parent", "MemberId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
