namespace MedicalInfo.Domain.Models;

public class Doctor
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;
    public Guid SpecializationId { get; set; }
    public Specialization Specialization { get; set; } = null!;
    public Guid? AreaId { get; set; }
    public Area Area { get; set; } = null!;
}