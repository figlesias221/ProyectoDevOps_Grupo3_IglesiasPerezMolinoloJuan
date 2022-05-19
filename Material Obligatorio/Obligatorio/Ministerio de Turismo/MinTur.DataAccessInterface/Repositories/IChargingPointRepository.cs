using MinTur.Domain.BusinessEntities;
using System;
using System.Collections.Generic;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IChargingPointRepository
    {
        ChargingPoint StoreChargingPoint(ChargingPoint chargingPoint);
    }
}
