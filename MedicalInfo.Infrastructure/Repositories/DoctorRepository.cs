#region usings

using MedicalInfo.Domain.Interfaces;
using MedicalInfo.Domain.Models;
using MedicalInfo.Infrastructure.Sorting;
using Microsoft.EntityFrameworkCore;

#endregion

namespace MedicalInfo.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly MsSqlDbContext _context;

    public DoctorRepository(MsSqlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Doctor>> GetAll(int pageIndex = 1, int pageSize = 0,
        string? sortField = null, bool sortAsc = true)
    {
        var query = _context.Doctors
            .Include(d => d.Area)
            .Include(d=>d.Specialization)
            .Include(d=>d.Room).AsQueryable();

        if (!string.IsNullOrEmpty(sortField))
        {
            query = new DoctorSortingHelper().Sort(query, sortField, sortAsc);
        }

        if (pageSize > 0)
        {
            query = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        return await query.ToArrayAsync();
    }

    public async Task<Doctor?> Get(Guid id)
    {
        return
            await _context.Doctors
                .Include(d => d.Area)
                .Include(d => d.Specialization)
                .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var doctor = await _context.Doctors.FindAsync(id);

        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);

            await _context.SaveChangesAsync();
        }
    }
}