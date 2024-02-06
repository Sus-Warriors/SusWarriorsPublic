using Ardalis.GuardClauses;
using SusWarriors.Application.Interfaces;
using SusWarriors.Application.Mappers;
using SusWarriors.Application.Models.ViewModels.MedItems;
using SusWarriors.Core.Interfaces.Data;
using SusWarriors.Core.Models;
using SusWarriors.Core.Models.MedItemAggregate;
using SusWarriors.Core.Models.Specifications.MedItemAggregate;
using SusWarriors.Core.Models.Specifications.MedItemCategory;

namespace SusWarriors.Application.Services;

public class MedItemService : IMedItemService
{
  private readonly IReadRepository<MedItem> _medItemReadRepository;
  private readonly IReadRepository<MedItemCategory> _medItemCategoryReadRepository;
  private readonly ILogger<MedItemService> _logger;

  public MedItemService(IReadRepository<MedItem> medItemReadRepository,
    IReadRepository<MedItemCategory> medItemCategoryReadRepository,
    ILogger<MedItemService> logger)
  {
    _medItemReadRepository = medItemReadRepository;
    _medItemCategoryReadRepository = medItemCategoryReadRepository;
    _logger = logger;
  }
  public async Task<List<MedItem>> GetMedItems()
  {
    var spec = new MedItemOrderedByNameSpec(true, true, false);
    return await _medItemReadRepository.ListAsync(spec);
  }

  public async Task<MedItem> GetMedItemByNameAsync(string name)
  {
    var spec = new MedItemByNameSpec(name, true, true, false);
    var medItem = await _medItemReadRepository.SingleOrDefaultAsync(spec);
    if (medItem is null)
      throw new NotFoundException(name, nameof(medItem));
    return medItem;
  }

  public async Task<RecommendedMedItemsViewModel> GetRecommendedMedItemsAsync(Guid currentMedItemId,
    Guid categoryId)
  {
    _logger.LogInformation($"{nameof(currentMedItemId)}:{currentMedItemId}, {nameof(categoryId)}:{categoryId}");
    Guard.Against.Default(currentMedItemId, nameof(currentMedItemId));
    Guard.Against.Default(categoryId, nameof(categoryId));
    var currentMedItemSpec = new MedItemByIdSpec(currentMedItemId, true, true, false);
    MedItem? currentMedItem = await _medItemReadRepository.SingleOrDefaultAsync(currentMedItemSpec);
    if (currentMedItem is null)
      throw new NotFoundException(currentMedItemId.ToString(), nameof(currentMedItem));
    MedItemWithCategory? currentMedItemWithCategory = currentMedItem.MedItemCategories
      .SingleOrDefault(x => x.MedItemCategoryId == categoryId);
    if (currentMedItemWithCategory is null)
    {
      currentMedItemWithCategory = currentMedItem.MedItemCategories.First(); // temp hack for FE
      categoryId = currentMedItemWithCategory.MedItemCategoryId;
    }
    var currentCategorySpec = new MedItemCategoryByIdSpec(categoryId, true, true, false);
    MedItemCategory? category = await _medItemCategoryReadRepository
      .SingleOrDefaultAsync(currentCategorySpec);
    if (category is null)
      throw new NotFoundException(categoryId.ToString(), nameof(category));
    IList<MedItemWithCategory> medItemWithCategories = category.MedItemCategoryRelationships;
    IList<MedItemWithCategory> otherMedItemWithCategories = medItemWithCategories
      .Where(x => x.MedItemId != currentMedItemId)
      .Where(x => x.Rating?.Value > (currentMedItemWithCategory.Rating?.Value ?? 0))
      .ToList();
    var otherMedItemsSpec = new MedItemsByIdsSpec(otherMedItemWithCategories
      .Select(x => x.MedItemId)
      .ToList(), false, true, false);
    IList<MedItem> otherMedItems = await _medItemReadRepository.ListAsync(otherMedItemsSpec);
    return MedItemMapper.MapMedItemsToRecommendedMedItemsViewModel(otherMedItems, categoryId);
  }
}
