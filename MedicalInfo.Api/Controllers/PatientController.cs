#region usings

using MedicalInfo.App.Interfaces;
using MedicalInfo.App.Models.Patient;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MedicalInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientListDto>>> GetAll([FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromQuery] string? sortField, [FromQuery] bool sortAsc = true)
    {
        return Ok(
            await _patientService.GetAll(pageIndex, pageSize, sortField, sortAsc));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PatientEditDto>> GetById(Guid id)
    {
        var result = await _patientService.Get(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Add(PatientPostDto patientDto)
    {
        await _patientService.Add(patientDto);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update(PatientEditDto patientDto)
    {
        await _patientService.Update(patientDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _patientService.Delete(id);

        return Ok();
    }
}