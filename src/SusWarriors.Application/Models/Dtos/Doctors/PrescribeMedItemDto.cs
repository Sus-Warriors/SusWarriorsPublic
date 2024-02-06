namespace SusWarriors.Application.Models.Dtos.Doctors;

public record PrescribeMedItemDto(Guid PatientId, Guid MedItemId, Guid MedItemCategoryId,
  decimal Dosage, Guid DoctorId);