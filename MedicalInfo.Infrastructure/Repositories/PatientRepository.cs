#region usings

using MedicalInfo.Domain.Interfaces;
using MedicalInfo.Domain.Models;
using MedicalInfo.Infrastructure.Sorting;
using Microsoft.EntityFrameworkCore;

#endregion

namespace MedicalInfo.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly MsSqlDbContext _context;

    public PatientRepository(MsSqlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAll(int pageIndex = 1, int pageSize = 0, 
        string? sortField = null, bool sortAsc = true)
    {
        var query = _context.Patients.Include(p => p.Area).AsQueryable();

        if (!string.IsNullOrEmpty(sortField))
        {
            query = new PatientSortingHelper().Sort(query, sortField, sortAsc);
        }

        if (pageSize > 0)
        {
            query = query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);
        }

        return await query.ToArrayAsync();
    }

    public async Task<Patient?> Get(Guid id)
    {
        return
            await _context.Patients
                .Include(p => p.Area)
                .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task Add(Patient patient)
    {
        _context.Patients.Add(patient);

        await _context.SaveChangesAsync();
    }

    public async Task Update(Patient patient)
    {
        _context.Patients.Update(patient);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient != null)
        {
            _context.Patients.Remove(patient);

            await _context.SaveChangesAsync();
        }
    }
}