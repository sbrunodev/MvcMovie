using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<MvcMovie.Models.Paciente> Paciente { get; set; }
        public DbSet<MvcMovie.Models.Protocolo> Protocolo { get; set; }
    }
}