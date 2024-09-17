using MedicalInfo.Domain.Models;

namespace MedicalInfo.Domain.Interfaces;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAll(int pageIndex, int pageSize, string? sortField, bool sortAsc);
    Task<Doctor?> Get(Guid id);
    Task Add(Doctor doctor);
    Task Update(Doctor doctor);
    Task Delete(Guid id);
}
