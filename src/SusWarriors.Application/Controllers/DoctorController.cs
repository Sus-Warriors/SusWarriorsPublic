using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SusWarriors.Application.Interfaces;
using SusWarriors.Application.Models.Dtos.Doctors;
using SusWarriors.Application.Models.ViewModels.Doctor;
using SusWarriors.Core.Models.DoctorAggregate;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
  private readonly IDoctorService _doctorService;

  public DoctorController(IDoctorService doctorService)
  {
    _doctorService = doctorService;
  }

  [HttpPost]
  [ProducesResponseType<DoctorPrescribedMedItemViewModel>(StatusCodes.Status200OK)]
  public async Task<IActionResult> PrescribeMedItemAsync([FromBody] PrescribeMedItemDto dto)
  {
    // temp
    var doctorId = dto.DoctorId;
    DoctorPrescribedMedItemViewModel medItem = await _doctorService.PrescribeMedItemForDoctor(doctorId,
      dto.PatientId, dto.MedItemId, dto.MedItemCategoryId, dto.Dosage);
    return Ok(medItem);
  }

  [HttpGet("{doctorId}/prescribedMedItems")]
  [ProducesResponseType<DoctorPrescribedMedItemsViewModel>(StatusCodes.Status200OK)]
  public async Task<IActionResult> GetPrescribedMedItemsAsync([FromRoute] Guid doctorId)
  {
    DoctorPrescribedMedItemsViewModel medItemsVm = await _doctorService
      .GetPrescribedMedItemsForDoctor(doctorId);
    return Ok(medItemsVm);
  }
}
