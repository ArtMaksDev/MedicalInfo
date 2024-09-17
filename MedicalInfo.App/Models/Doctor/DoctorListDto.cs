namespace MedicalInfo.App.Models.Doctor;

public class DoctorListDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string SpecializationName { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int AreaNumber { get; set; }
}