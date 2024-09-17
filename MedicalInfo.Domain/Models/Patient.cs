namespace MedicalInfo.Domain.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string LastName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string MiddleName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public Guid AreaId { get; set; }
    public Area Area { get; set; } = null!;
}