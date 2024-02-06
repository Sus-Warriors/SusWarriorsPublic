namespace SusWarriors.Application.Models.ViewModels.MedItems;

public record MedItemSustainabilityViewModel(MedItemWithCategoryRatingViewModel Rating,
  MedItemEmissionViewModel Emissions);
