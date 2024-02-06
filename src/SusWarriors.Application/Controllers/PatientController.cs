using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using SusWarriors.Application.Mappers;
using SusWarriors.Application.Models.ViewModels.Patient;
using SusWarriors.Core.Interfaces.Services.PatientAggregate;
using SusWarriors.Core.Models.PatientAggregate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SusWarriors.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
  private readonly IPatientService _patientService;

  public PatientController(IPatientService patientService)
  {
    _patientService = patientService;
  }

  [HttpGet("identifierno/{identifierNumber}")]
  [ProducesResponseType<PatientViewModel>(200)]
  [ProducesResponseType<PatientViewModel>(400)]
  public async Task<IActionResult> GetByIdentifierNumberAsync([FromRoute] string identifierNumber)
  {
    try
    {
      Patient patient = await _patientService.GetPatientByIdentifierNumber(identifierNumber);
      return Ok(PatientMapper.MapPatientToViewModel(patient));
    } catch (NotFoundException)
    {
      return BadRequest(new PatientViewModel(Guid.Empty, "N/A", 0, identifierNumber, "N/A", "N/A"));
    }
  }
}
