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

        public int RegisterChargingPoint(ChargingPoint chargingPoint)
        {
            chargingPoint.ValidOrFail();

            int newChargingPointId = _repositoryFacade.StoreChargingPoint(chargingPoint);

            return newChargingPointId;
        }
    }
}