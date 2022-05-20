using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Domain.SearchCriteria;
using System;
using System.Collections.Generic;

namespace MinTur.BusinessLogic.ResourceManagers
{
    public class ChargingPointManager : IChargingPointManager
    {
        private readonly IRepositoryFacade _repositoryFacade;

        public ChargingPointManager(IRepositoryFacade repositoryFacade)
        {
            _repositoryFacade = repositoryFacade;
        }

        public ChargingPoint RegisterChargingPoint(ChargingPoint chargingPoint)
        {
            chargingPoint.ValidOrFail();

            ChargingPoint newChargingPoint = _repositoryFacade.StoreChargingPoint(chargingPoint);

            return newChargingPoint;
        }

        public ChargingPoint DeleteChargingPoint(int id)
        {
            ChargingPoint deletedChargingPoint = _repositoryFacade.DeleteChargingPoint(id);
            
            return deletedChargingPoint;
        }
    }
}