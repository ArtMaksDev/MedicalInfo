#region usings

using MedicalInfo.App.Models.Patient;

#endregion

namespace MedicalInfo.App.Interfaces;

public interface IPatientService
{
    public  Task<IEnumerable<PatientListDto>> GetAll(int pageIndex = 1, int pageSize = 0,
        string? sortField = null, bool sortAsc = true);
    public  Task<PatientEditDto?> Get(Guid id);
    public  Task Add(PatientPostDto patientDto);
    public Task Update(PatientEditDto patientDto);
    public Task Delete(Guid id);
}