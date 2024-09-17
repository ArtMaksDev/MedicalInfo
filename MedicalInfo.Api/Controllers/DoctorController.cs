#region usings

using MedicalInfo.App.Interfaces;
using MedicalInfo.App.Models.Doctor;
using MedicalInfo.App.Models.Patient;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MedicalInfo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorListDto>>> GetAll([FromQuery] int pageIndex,
        [FromQuery] int pageSize, [FromQuery] string? sortField, [FromQuery] bool sortAsc = true)
    {
        return Ok(
            await _doctorService.GetAll(pageIndex, pageSize, sortField, sortAsc));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorEditDto>> GetById(Guid id)
    {
        var result = await _doctorService.Get(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> Add(DoctorPostDto doctorDto)
    {
        await _doctorService.Add(doctorDto);

        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> Update(DoctorEditDto doctorDto)
    {
        await _doctorService.Update(doctorDto);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _doctorService.Delete(id);

        return Ok();
    }
}