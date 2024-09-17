#region usings

using AutoMapper;
using MedicalInfo.App.Models.Doctor;
using MedicalInfo.App.Models.Patient;
using MedicalInfo.Domain.Models;

#endregion

namespace MedicalInfo.App.Mappings;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorEditDto>().ReverseMap();

        CreateMap<Doctor, DoctorListDto>()
            .ForMember(dest => dest.AreaNumber, opt => opt.MapFrom(src => src.Area.Number))
            .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room.Number));

        CreateMap<DoctorPostDto, Doctor>();
    }
}