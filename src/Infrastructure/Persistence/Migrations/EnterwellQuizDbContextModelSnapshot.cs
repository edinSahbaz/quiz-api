﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(EnterwellQuizDbContext))]
    partial class EnterwellQuizDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prompt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Entities.Quiz", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuestionQuiz", b =>
                {
                    b.Property<Guid>("QuestionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuizzesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("QuestionsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuestionQuiz");
                });

            modelBuilder.Entity("QuestionQuiz", b =>
                {
                    b.HasOne("Domain.Entities.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
