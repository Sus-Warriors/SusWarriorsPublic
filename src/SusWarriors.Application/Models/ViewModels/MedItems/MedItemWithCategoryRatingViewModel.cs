namespace SusWarriors.Application.Models.ViewModels.MedItems;

public record MedItemWithCategoryRatingViewModel(Guid Id, string CategoryName, string FQName, 
  decimal RatingValue);
