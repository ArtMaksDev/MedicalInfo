using MedicalInfo.Domain.Models;

namespace MedicalInfo.Domain.Interfaces;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAll(int pageIndex, int pageSize, string? sortField, bool sortAsc);
    Task<Patient?> Get(Guid id);
    Task Add(Patient patient);
    Task Update(Patient patient);
    Task Delete(Guid id);
}