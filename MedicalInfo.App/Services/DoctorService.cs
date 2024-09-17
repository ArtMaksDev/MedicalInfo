#region usings

using AutoMapper;
using MedicalInfo.App.Interfaces;
using MedicalInfo.App.Models.Doctor;
using MedicalInfo.Domain.Interfaces;
using MedicalInfo.Domain.Models;

#endregion

namespace MedicalInfo.App.Services;

public class DoctorService :IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;

    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DoctorListDto>> GetAll(int pageIndex = 1, int pageSize = 0,
        string? sortField = null, bool sortAsc = true)
    {
        var doctors = await _doctorRepository.GetAll(pageIndex, pageSize, sortField, sortAsc);

        return _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorListDto>>(doctors);
    }

    public async Task<DoctorEditDto?> Get(Guid id)
    {
        var doctor = await _doctorRepository.Get(id);

        return _mapper.Map<Doctor?, DoctorEditDto>(doctor);
    }

    public async Task Add(DoctorPostDto doctorDto)
    {
        var doctor = _mapper.Map<DoctorPostDto, Doctor>(doctorDto);

        await _doctorRepository.Add(doctor);
    }

    public async Task Update(DoctorEditDto doctorDto)
    {
        var doctor = _mapper.Map<Doctor>(doctorDto);
        await _doctorRepository.Update(doctor);
    }

    public async Task Delete(Guid id)
    {
        await _doctorRepository.Delete(id);
    }
}