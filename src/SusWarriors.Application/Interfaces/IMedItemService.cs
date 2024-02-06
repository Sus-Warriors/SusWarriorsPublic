using SusWarriors.Application.Models.ViewModels.MedItems;
using SusWarriors.Core.Models.MedItemAggregate;

namespace SusWarriors.Application.Interfaces;

public interface IMedItemService
{
  Task<List<MedItem>> GetMedItems();
  Task<MedItem> GetMedItemByNameAsync(string name);
  Task<RecommendedMedItemsViewModel> GetRecommendedMedItemsAsync(Guid currentMedItemId, Guid categoryId);
}
