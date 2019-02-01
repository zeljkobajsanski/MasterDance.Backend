using System.Security.Cryptography.X509Certificates;
using MasterDance.Domain.Entities;

namespace MasterDance.Application.UseCases.Competitions.Models
{
    public static class Extensions
    {
        public static CompetitionModel ToModel(this Competition entity)
        {
            return new CompetitionModel() {Id = entity.Id, Name = entity.Name, City = entity.City, Date = entity.Date};
        }

        public static Competition ToEntity(this CompetitionModel model)
        {
            return new Competition() {Id = model.Id, Name = model.Name, City = model.City, Date = model.Date};
        }
    }
}