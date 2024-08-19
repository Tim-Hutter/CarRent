using CarRent.Common.Domain;

namespace CarRent.Feature.Cars.Domain
{
    public interface ICarRepository : IRepository<Car>
    {
        IReadOnlyList<Car> GetCars();
    }
}
