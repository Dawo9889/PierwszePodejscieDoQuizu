﻿using Microsoft.EntityFrameworkCore;
using PierwszePodejscieDoQuizu.Database.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PierwszePodejscieDoQuizu.Database
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string currentDirectory = Directory.GetCurrentDirectory();
            string projectDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent.FullName;
            string databasePath = Path.Combine(projectDirectory, "Quizzes.sqlite");

            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                        .HasMany(q => q.Questions)
                        .WithOne(q => q.Quiz)
                        .HasForeignKey(q => q.QuizId);

            modelBuilder.Entity<Question>()
                        .HasMany(q => q.Answers)
                        .WithOne(a => a.Question)
                        .HasForeignKey(a => a.QuestionId);
        }
    }

}
