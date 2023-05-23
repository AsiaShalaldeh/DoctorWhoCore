﻿// <auto-generated />
using System;
using DoctorWho.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorWho.DB.Migrations
{
    [DbContext(typeof(DoctorWhoCoreDbContext))]
    partial class DoctorWhoCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DoctorWho.DB.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorName = "John Doe"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorName = "Jane Doe"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorName = "Bob Smith"
                        },
                        new
                        {
                            AuthorId = 4,
                            AuthorName = "Alice Johnson"
                        },
                        new
                        {
                            AuthorId = 5,
                            AuthorName = "Tom Lee"
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.Companion", b =>
                {
                    b.Property<int>("CompanionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanionId"));

                    b.Property<string>("CompanionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WhoPlayed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanionId");

                    b.ToTable("Companions");

                    b.HasData(
                        new
                        {
                            CompanionId = 1,
                            CompanionName = "Rose Tyler",
                            WhoPlayed = "Billie Piper"
                        },
                        new
                        {
                            CompanionId = 2,
                            CompanionName = "Martha Jones",
                            WhoPlayed = "Freema Agyeman"
                        },
                        new
                        {
                            CompanionId = 3,
                            CompanionName = "Donna Noble",
                            WhoPlayed = "Catherine Tate"
                        },
                        new
                        {
                            CompanionId = 4,
                            CompanionName = "Amy Pond",
                            WhoPlayed = "Karen Gillan"
                        },
                        new
                        {
                            CompanionId = 5,
                            CompanionName = "Clara Oswald",
                            WhoPlayed = "Jenna Coleman"
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.CompanionDto", b =>
                {
                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.Property<string>("CompanionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("num_companions")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("DoctorWho.DB.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("FirstEpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastEpisodeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "John Smith",
                            DoctorNumber = 1234,
                            FirstEpisodeDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 2,
                            BirthDate = new DateTime(1975, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Jane Doe",
                            DoctorNumber = 5678,
                            FirstEpisodeDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 3,
                            BirthDate = new DateTime(1990, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Bob Johnson",
                            DoctorNumber = 9012,
                            FirstEpisodeDate = new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 4,
                            BirthDate = new DateTime(1985, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Alice Lee",
                            DoctorNumber = 3456,
                            FirstEpisodeDate = new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            DoctorId = 5,
                            BirthDate = new DateTime(1970, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorName = "Tom Wilson",
                            DoctorNumber = 7890,
                            FirstEpisodeDate = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastEpisodeDate = new DateTime(2020, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemies");

                    b.HasData(
                        new
                        {
                            EnemyId = 1,
                            Description = "Exterminate! Exterminate!",
                            EnemyName = "Daleks"
                        },
                        new
                        {
                            EnemyId = 2,
                            Description = "Upgrade in progress.",
                            EnemyName = "Cybermen"
                        },
                        new
                        {
                            EnemyId = 3,
                            Description = "Oh, you know who I am.",
                            EnemyName = "The Master"
                        },
                        new
                        {
                            EnemyId = 4,
                            Description = "Don't blink!",
                            EnemyName = "Weeping Angels"
                        },
                        new
                        {
                            EnemyId = 5,
                            Description = "You forget them as soon as you look away.",
                            EnemyName = "Silence"
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.EnemyDto", b =>
                {
                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.Property<string>("EnemyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("num_enemies")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("DoctorWho.DB.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EpisodeId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EpisodeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriesNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EpisodeId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            AuthorId = 1,
                            DoctorId = 1,
                            EpisodeDate = new DateTime(1963, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 1,
                            EpisodeType = "Regular",
                            Notes = "First appearance of the Doctor and the TARDIS.",
                            SeriesNumber = 1,
                            Title = "An Unearthly Child"
                        },
                        new
                        {
                            EpisodeId = 2,
                            AuthorId = 2,
                            DoctorId = 1,
                            EpisodeDate = new DateTime(1965, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 4,
                            EpisodeType = "Regular",
                            Notes = "Historical adventure featuring the first Doctor.",
                            SeriesNumber = 2,
                            Title = "The Romans"
                        },
                        new
                        {
                            EpisodeId = 3,
                            AuthorId = 3,
                            DoctorId = 2,
                            EpisodeDate = new DateTime(1966, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 10,
                            EpisodeType = "Regular",
                            Notes = "First appearance of Ben and Polly.",
                            SeriesNumber = 3,
                            Title = "The War Machines"
                        },
                        new
                        {
                            EpisodeId = 4,
                            AuthorId = 4,
                            DoctorId = 2,
                            EpisodeDate = new DateTime(1966, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 2,
                            EpisodeType = "Regular",
                            Notes = "Historical adventure featuring the second Doctor.",
                            SeriesNumber = 4,
                            Title = "The Highlanders"
                        },
                        new
                        {
                            EpisodeId = 5,
                            AuthorId = 5,
                            DoctorId = 2,
                            EpisodeDate = new DateTime(1967, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EpisodeNumber = 1,
                            EpisodeType = "Regular",
                            Notes = "First appearance of Victoria Waterfield.",
                            SeriesNumber = 5,
                            Title = "Tomb of the Cybermen"
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.EpisodeCompanion", b =>
                {
                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int>("CompanionId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeId", "CompanionId");

                    b.HasIndex("CompanionId");

                    b.ToTable("EpisodeCompanions");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            CompanionId = 2
                        },
                        new
                        {
                            EpisodeId = 3,
                            CompanionId = 2
                        },
                        new
                        {
                            EpisodeId = 5,
                            CompanionId = 1
                        },
                        new
                        {
                            EpisodeId = 3,
                            CompanionId = 4
                        },
                        new
                        {
                            EpisodeId = 2,
                            CompanionId = 5
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.EpisodeEnemy", b =>
                {
                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<int>("EnemyId")
                        .HasColumnType("int");

                    b.HasKey("EpisodeId", "EnemyId");

                    b.HasIndex("EnemyId");

                    b.ToTable("EpisodeEnemies");

                    b.HasData(
                        new
                        {
                            EpisodeId = 1,
                            EnemyId = 2
                        },
                        new
                        {
                            EpisodeId = 3,
                            EnemyId = 2
                        },
                        new
                        {
                            EpisodeId = 5,
                            EnemyId = 1
                        },
                        new
                        {
                            EpisodeId = 3,
                            EnemyId = 4
                        },
                        new
                        {
                            EpisodeId = 2,
                            EnemyId = 5
                        });
                });

            modelBuilder.Entity("DoctorWho.DB.EpisodeSummary", b =>
                {
                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView(null, (string)null);
                });

            modelBuilder.Entity("DoctorWho.DB.Episode", b =>
                {
                    b.HasOne("DoctorWho.DB.Author", null)
                        .WithMany("Episodes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.DB.Doctor", null)
                        .WithMany("Episodes")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DoctorWho.DB.EpisodeCompanion", b =>
                {
                    b.HasOne("DoctorWho.DB.Companion", "Companion")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("CompanionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.DB.Episode", "Episode")
                        .WithMany("EpisodeCompanions")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companion");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.DB.EpisodeEnemy", b =>
                {
                    b.HasOne("DoctorWho.DB.Enemy", "Enemy")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EnemyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoctorWho.DB.Episode", "Episode")
                        .WithMany("EpisodeEnemies")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enemy");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("DoctorWho.DB.Author", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.DB.Companion", b =>
                {
                    b.Navigation("EpisodeCompanions");
                });

            modelBuilder.Entity("DoctorWho.DB.Doctor", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("DoctorWho.DB.Enemy", b =>
                {
                    b.Navigation("EpisodeEnemies");
                });

            modelBuilder.Entity("DoctorWho.DB.Episode", b =>
                {
                    b.Navigation("EpisodeCompanions");

                    b.Navigation("EpisodeEnemies");
                });
#pragma warning restore 612, 618
        }
    }
}
