#region usings

using MedicalInfo.App.Models.Doctor;

#endregion

namespace MedicalInfo.App.Interfaces;

public interface IDoctorService
{
    public Task<IEnumerable<DoctorListDto>> GetAll(int pageIndex = 1, int pageSize = 0,
        string? sortField = null, bool sortAsc = true);

    public Task<DoctorEditDto?> Get(Guid id);
    public Task Add(DoctorPostDto doctorDto);
    public Task Update(DoctorEditDto doctorDto);
    public Task Delete(Guid id);
}