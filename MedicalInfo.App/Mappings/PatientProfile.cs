using AutoMapper;
using MedicalInfo.Domain.Models;
using MedicalInfo.App.Models.Patient;

namespace MedicalInfo.App.Mappings;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientEditDto>().ReverseMap();

        CreateMap<Patient, PatientListDto>()
            .ForMember(dest => dest.AreaNumber, opt => opt.MapFrom(src => src.Area.Number));

        CreateMap<PatientPostDto, Patient>();
    }
}