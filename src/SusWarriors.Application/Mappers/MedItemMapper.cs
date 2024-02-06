using SusWarriors.Application.Models.ViewModels.MedItems;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Application.Mappers;

public static class MedItemMapper
{
  public static MedItemViewModel MapMedItemToViewModel(MedItem medItem)
  {
    return new MedItemViewModel(medItem.Id, medItem.Name, medItem.DosageWeight,
      MapEmissionsToViewModel(medItem.Emissions),
      medItem.MedItemCategories
        .Select(x => MapMedItemWithCategoryToViewModel(medItem, x))
        .ToList());
  }

  public static MedItemEmissionViewModel? MapEmissionsToViewModel(MedItemEmissions? emissions)
  {
    return emissions is null ? null : new MedItemEmissionViewModel(emissions.EmissionValue);
  }
  
  public static MedItemWithCategoryRatingViewModel MapMedItemWithCategoryToViewModel(MedItem medItem,
    MedItemWithCategory category)
  {
    return new MedItemWithCategoryRatingViewModel(category.MedItemCategoryId, category.MedItemCategory!.Name,
      $"{medItem.Name} ({category.MedItemCategory!.Name})", category.Rating!.Value);
  }

  public static RecommendedMedItemsViewModel MapMedItemsToRecommendedMedItemsViewModel(
    ICollection<MedItem> medItems, Guid categoryId)
  {
    return new RecommendedMedItemsViewModel(medItems
      .Select(x => MapMedItemToRecommendedMedItemViewModel(x, categoryId))
      .OrderByDescending(x => x.CategoryRating.RatingValue)
      .ToList());
  }

  public static RecommendedMedItemViewModel MapMedItemToRecommendedMedItemViewModel(MedItem medItem,
    Guid categoryId)
  {
    MedItemWithCategory medItemWithCategory = medItem.MedItemCategories
      .Single(x => x.MedItemCategoryId == categoryId);
    return new RecommendedMedItemViewModel(medItem.Id, medItem.Name,
      MapMedItemWithCategoryToViewModel(medItem, medItemWithCategory));
  }

}
