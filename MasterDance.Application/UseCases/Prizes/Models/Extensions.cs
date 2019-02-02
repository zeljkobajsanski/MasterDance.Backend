using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Prizes.Models
{
    public static class Extensions
    {
        public static Prize ToEntity(this PrizeModel model)
        {
            return new Prize()
            {
                Id = model.Id,
                MemberId = model.MemberId,
                CompetitionId = model.CompetitionId,
                Title = model.Title,
                Category = model.Category,
                Choreography = model.Choreography
            };
        }

        public static PrizeModel ToModel(this Prize entity)
        {
            return new PrizeModel()
            {
                Id = entity.Id,
                MemberId = entity.MemberId,
                CompetitionId = entity.CompetitionId,
                CompetitionDate = entity.Competition?.Date,
                CompetitionName = entity.Competition?.Name,
                Title = entity.Title,
                Category = entity.Category,
                Choreography = entity.Choreography
            };
        }
    }
}