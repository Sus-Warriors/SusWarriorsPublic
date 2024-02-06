namespace SusWarriors.Application.Models.ViewModels.MedItems;

public record RecommendedMedItemsViewModel(List<RecommendedMedItemViewModel> medItemViewModel);

public record RecommendedMedItemViewModel(Guid Id, string MedItemName,
  MedItemWithCategoryRatingViewModel CategoryRating);