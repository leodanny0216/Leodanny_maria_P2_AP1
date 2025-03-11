using Leodanny_maria_P2_AP1.Models;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Leodanny_maria_P2_AP1.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
          : base(options) { }
    public DbSet<Ciudades> Ciudades { get; set; }
    public DbSet<Encuestas> Encuesta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Ciudades>().HasData(new List<Ciudades>()
    {
        new Ciudades() {CiudadId= 1, NombreCiudad ="Nagua", Monto=1500},
        new Ciudades { CiudadId= 2, NombreCiudad  = "SFM", Monto=50000},
        new Ciudades { CiudadId= 3, NombreCiudad  = "Villa Riva", Monto= 3}
    });
    }
}