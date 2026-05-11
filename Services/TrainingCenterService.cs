using Microsoft.EntityFrameworkCore;
using TrainingCenterRegistry.Data;
using TrainingCenterRegistry.Models;

namespace TrainingCenterRegistry.Services
{
    public class TrainingCenterService : ITrainingCenterService
    {
        private readonly ApplicationDbContext _context;

        public TrainingCenterService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TrainingCenter> AddTrainingCenterAsync(
            TrainingCenter center)
        {
            // Generate timestamp from backend
            center.CreatedOn =
                DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            _context.TrainingCenters.Add(center);

            await _context.SaveChangesAsync();

            return center;
        }

        public async Task<List<TrainingCenter>>
            GetTrainingCentersAsync(string? city)
        {
            IQueryable<TrainingCenter> query =
                _context.TrainingCenters;

            // Optional city filter
            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(x =>
                    x.Address.City == city);
            }

            return await query.ToListAsync();
        }
    }
}
