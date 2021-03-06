using System.Collections.Generic;
using System.Linq;
using MinTur.DataAccessInterface.Repositories;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

namespace MinTur.DataAccess.Repositories
{
    public class ChargingPointRepository : IChargingPointRepository
    {
        protected DbContext Context { get; set; }

        public ChargingPointRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public ChargingPoint StoreChargingPoint(ChargingPoint chargingPoint)
        {
            if (!RegionExists(chargingPoint.RegionId))
                throw new ResourceNotFoundException("Could not find specified region");

            if (ChargingPointExists(chargingPoint.FourDigit))
                throw new InvalidOperationException("Charging point con este id ya existe.");
            
            chargingPoint.Region = Context.Set<Region>().Where(r => r.Id == chargingPoint.RegionId).FirstOrDefault();
            StoreChargingPointInDb(chargingPoint);

            return chargingPoint;
        }

        public ChargingPoint DeleteChargingPoint(int id)
        {
            ChargingPoint toDelete = Context.Set<ChargingPoint>().Where(c => id == c.FourDigit).FirstOrDefault();
            
            if (toDelete == null)
            {
                throw new ResourceNotFoundException(
                    $"Charging point with {id} does not exist and could not be deleted");
            }

            Context.Set<ChargingPoint>().Remove(toDelete);
            Context.SaveChanges();

            return toDelete;
        }

        private bool RegionExists(int regionId)
        {
            Region region = Context.Set<Region>().AsNoTracking().Where(r => r.Id == regionId).FirstOrDefault();
            
            return region != null;
        }
        private void StoreChargingPointInDb(ChargingPoint chargingPoint) 
        {
            Context.Entry(chargingPoint.Region).State = EntityState.Unchanged; 

            Context.Set<ChargingPoint>().Add(chargingPoint);
            Context.SaveChanges();

            Context.Entry(chargingPoint.Region).State = EntityState.Detached;
        }

        private bool ChargingPointExists(int fourDigitId)
        {
            ChargingPoint chargingPoint = Context.Set<ChargingPoint>().AsNoTracking().Where(c => c.FourDigit == fourDigitId).FirstOrDefault();
            
            return chargingPoint != null;
        }
    }
}