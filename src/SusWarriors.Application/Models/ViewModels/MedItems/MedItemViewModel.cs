using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Application.Models.ViewModels.MedItems;

public record MedItemViewModel(Guid Id,string Name, decimal DosageWeight, 
  MedItemEmissionViewModel? Emissions, IList<MedItemWithCategoryRatingViewModel> categories);

public record MedItemEmissionViewModel(decimal Value);

