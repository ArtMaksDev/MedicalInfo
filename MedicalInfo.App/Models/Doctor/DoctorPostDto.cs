namespace MedicalInfo.App.Models.Doctor;

public class DoctorPostDto
{
    public string FullName { get; set; } = null!;
    public Guid RoomId { get; set; }
    public Guid SpecializationId { get; set; }
    public Guid? AreaId { get; set; }
}