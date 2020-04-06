﻿using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace HelpLocally.Infrastructure
{
    public class HelpLocallyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(DbContextOptionsBuilder => { DbContextOptionsBuilder.AddConsole(); });

        public HelpLocallyContext(DbContextOptions<HelpLocallyContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(DbLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
