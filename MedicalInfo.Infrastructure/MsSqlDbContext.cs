using MedicalInfo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalInfo.Infrastructure;

public class MsSqlDbContext : DbContext
{
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Area> Areas { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Specialization> Specializations { get; set; } = null!;

    public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options)
        : base(options)
    {
    }

}