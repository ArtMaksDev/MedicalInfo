#region usings

using AutoMapper;
using MedicalInfo.App.Interfaces;
using MedicalInfo.App.Models.Patient;
using MedicalInfo.Domain.Interfaces;
using MedicalInfo.Domain.Models;

#endregion

namespace MedicalInfo.App.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientListDto>> GetAll(int pageIndex = 1, int pageSize = 0,
        string? sortField = null, bool sortAsc = true)
    {
        var patients = await _patientRepository.GetAll(pageIndex, pageSize, sortField, sortAsc);

        return _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientListDto>>(patients);
    }

    public async Task<PatientEditDto?> Get(Guid id)
    {
        var patient = await _patientRepository.Get(id);

        return _mapper.Map<Patient, PatientEditDto>(patient);
    }

    public async Task Add(PatientPostDto patientDto)
    {
        var patient = _mapper.Map<PatientPostDto, Patient>(patientDto);

        await _patientRepository.Add(patient);
    }

    public async Task Update(PatientEditDto patientDto)
    {
        var patient = _mapper.Map<Patient>(patientDto);
        await _patientRepository.Update(patient);
    }

    public async Task Delete(Guid id)
    {
        await _patientRepository.Delete(id);
    }
}