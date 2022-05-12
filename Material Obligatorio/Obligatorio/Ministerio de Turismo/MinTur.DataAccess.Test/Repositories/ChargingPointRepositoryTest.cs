using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MinTur.DataAccess.Contexts;
using MinTur.Domain.BusinessEntities;
using MinTur.DataAccess.Repositories;
using System.Linq;
using MinTur.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MinTur.DataAccess.Test.Repositories
{
    [TestClass]
    public class ChargingPointRepositoryTest
    {
        private ChargingPointRepository _repository;
        private NaturalUruguayContext _context;

        [TestInitialize]
        public void SetUp()
        {
            _context = ContextFactory.GetNewContext(ContextType.Memory);
            _context.Database.EnsureDeleted();
            _repository = new ChargingPointRepository(_context);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void StoreChargingPointReturnsAsExpected() 
        {
            ChargingPoint touristPoint = LoadRelatedEntitiesAndCreateChargingPoint();
            int newChargingPointId = _repository.StoreChargingPoint(touristPoint);

            Assert.AreEqual(touristPoint.Id, newChargingPointId);
            Assert.IsNotNull(_context.ChargingPoints.Where(t => t.Id == newChargingPointId).FirstOrDefault());
        }

        [TestMethod]
        [ExpectedException(typeof(ResourceNotFoundException))]
        public void StoreChargingPointNonExistentRegion()
        {
            ChargingPoint touristPoint = LoadRelatedEntitiesAndCreateChargingPoint();
            touristPoint.RegionId = -4;

            _repository.StoreChargingPoint(touristPoint);
        }

        #region Helpers
        public ChargingPoint CreateChargingPoint()
        {
            return new ChargingPoint()
            {
                Name = "Hotel Italiano",
                Description = "Descripcion sobre el hotel....",
                RegionId = 2,
                Region = new Region() { Id = 2, Name = "Metropolitana" },
            };
        }
        
        public ChargingPoint LoadRelatedEntitiesAndCreateChargingPoint() 
        {
            Region region = new Region() { Name = "Metropolitana" };

            _context.Regions.Add(region);
            _context.SaveChanges();
            _context.Entry(region).State = EntityState.Detached;

            ChargingPoint newChargingPoint =  new ChargingPoint()
            {
                Name = "Hotel Italiano",
                Description = "Descripcion sobre el hotel....",
                RegionId = region.Id
            };

            return newChargingPoint;
        }
        
        private void LoadChargingPoints(List<ChargingPoint> touristPoints)
        {
            Region region1 = new Region() { Name = "Metropolitana" };
            Region region2 = new Region() { Name = "Centro Sur" };

            ChargingPoint touristPoint1 = new ChargingPoint()
            {
                Name = "Punta Del Este",
                Description = "Donde el lujo y la naturaleza convergen: Punta del Este es reconocido internacionalmente como...",
                RegionId = region1.Id,
                Region = region1,
            };

            ChargingPoint touristPoint2 = new ChargingPoint()
            {
                Name = "Cabo Polonio",
                Description = "Donde el lujo y la naturaleza convergen: Punta del Este es reconocido internacionalmente como...",
                RegionId = region2.Id,
                Region = region2,
            };

            Resort resort = new Resort()
            {
                Id = 3,
                Name = "Hotel Italiano",
            };
            resort.Images.Add(new Image() { Id = 3, Data = "uhfadsuhf" });

            touristPoints.Add(touristPoint1);
            touristPoints.Add(touristPoint2);

            _context.Regions.Add(region1);
            _context.Regions.Add(region2);
            _context.ChargingPoints.Add(touristPoint1);
            _context.ChargingPoints.Add(touristPoint2);
            _context.SaveChanges();
        }
        private void LoadResorts(ChargingPoint relatedChargingPoint)
        {
            Resort resort1 = new Resort()
            {
                Id = 3,
                Address = "Direccion",
                Description = "Descripcion ....",
                Name = "Hotel Italiano",
                PricePerNight = 520,
                Stars = 4,
            };
            Resort resort2 = new Resort()
            {
                Id = 9,
                Address = "Direccion 2",
                Description = "Descripcion 2 ....",
                Name = "Hotel Aleman",
                PricePerNight = 330,
                Stars = 5,
            };
            resort1.Images.Add(new Image() { Id = 5, Data = "sdafasdgwe" });

            _context.ChargingPoints.Add(relatedChargingPoint);
            _context.SaveChanges();
        }
        #endregion

    }
}