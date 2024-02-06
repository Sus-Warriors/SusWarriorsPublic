using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SusWarriors.Application.Interfaces;
using SusWarriors.Application.Mappers;
using SusWarriors.Application.Models.Dtos.MedItems;
using SusWarriors.Application.Models.ViewModels.MedItems;

namespace SusWarriors.Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MedItemController : ControllerBase
{
  private readonly IMedItemService _medItemService;

  public MedItemController(IMedItemService medItemService)
  {
    _medItemService = medItemService;
  }

  [HttpGet("list")]
  [ProducesResponseType<ListMedItemsViewModel>(200)]
  public async Task<IActionResult> ListAsync()
  {
    var medItems = await _medItemService.GetMedItems();
    return Ok(new ListMedItemsViewModel(medItems.Select(
      MedItemMapper.MapMedItemToViewModel).ToList()));
  }

  [HttpGet("name/{name}")]
  [ProducesResponseType<MedItemViewModel>(200)]
  public async Task<IActionResult> GetByNameAsync([FromRoute] string name)
  {
    var medItem = await _medItemService.GetMedItemByNameAsync(name);
    return Ok(MedItemMapper.MapMedItemToViewModel(medItem));
  }

  [HttpPost("recommend")]
  [ProducesResponseType<RecommendedMedItemsViewModel>(200)]
  public async Task<IActionResult> GetRecommendedMedItemsAsync([FromBody] GetRecommendedMedItemsDto dto)
  {
    var recommendMedItems = await _medItemService.GetRecommendedMedItemsAsync(dto.medItemId,
      dto.categoryId);
    return Ok(recommendMedItems);
  }

}
