using MinTur.DataAccessInterface.Repositories;

namespace MinTur.DataAccessInterface.Facades
{
    public interface IRepositoryFacade : IRegionRepository, ITouristPointRepository, IChargingPointRepository, ICategoryRepository, IResortRepository, IReservationRepository,
        IAuthenticationTokenRepository, IAdministratorRepository, IReviewRepository
    {

    }
}
