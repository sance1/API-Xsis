using System;
using Microsoft.EntityFrameworkCore;
using AssessmentBackendDeveloperXsis2023.Models;

namespace AssessmentBackendDeveloperXsis2023.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Movie> Movies { get; set; }

    }
}

