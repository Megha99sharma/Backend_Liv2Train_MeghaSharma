using TrainingCenterRegistry.Models;

namespace TrainingCenterRegistry.Services
{
    public interface ITrainingCenterService
    {
        Task<TrainingCenter> AddTrainingCenterAsync(
            TrainingCenter center);

        Task<List<TrainingCenter>> GetTrainingCentersAsync(
            string? city);
    }
}
