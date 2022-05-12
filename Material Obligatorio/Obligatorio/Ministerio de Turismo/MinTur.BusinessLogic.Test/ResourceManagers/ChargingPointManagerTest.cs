using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccessInterface.Facades;
using MinTur.Domain.BusinessEntities;
using System.Collections.Generic;
using MinTur.Domain.SearchCriteria;

namespace MinTur.BusinessLogic.Test.ResourceManagers
{
    [TestClass]
    public class ChargingPointManagerTest
    {
        private List<ChargingPoint> _chargingPoints;
        private List<Resort> _resorts;
        private Mock<IRepositoryFacade> _repositoryFacadeMock;
        private Mock<ChargingPoint> _chargingPointMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingPoints = new List<ChargingPoint>();
            _resorts = new List<Resort>();
            _repositoryFacadeMock = new Mock<IRepositoryFacade>(MockBehavior.Strict);
            _chargingPointMock = new Mock<ChargingPoint>(MockBehavior.Strict);

            LoadChargingPoints();
        }

        private void LoadChargingPoints()
        {
            Region region1 = new Region() { Id = 0, Name = "Metropolitana" };
            Region region2 = new Region() { Id = 1, Name = "Centro Sur" };

            ChargingPoint chargingPoint1 = new ChargingPoint()
            {
                Id = 0,
                Name = "Punta Del Este",
                Description = "Donde el lujo y la naturaleza convergen: Punta del Este es reconocido internacionalmente como...",
                RegionId = region1.Id,
                Region = region1,
            };

            ChargingPoint chargingPoint2 = new ChargingPoint()
            {
                Id = 1,
                Name = "Cabo Polonio",
                Description = "Donde el lujo y la naturaleza convergen: Punta del Este es reconocido internacionalmente como...",
                RegionId = region2.Id,
                Region = region2,
            };

        }
        #endregion


        [TestMethod]
        public void RegisterChargingPointReturnsAsExpected() 
        {
            int newChargingPointId = 94;
            ChargingPoint createdChargingPoint = CreateChargingPointWithSpecificId(newChargingPointId);

            _chargingPointMock.Setup(t => t.ValidOrFail());
            _repositoryFacadeMock.Setup(r => r.StoreChargingPoint(_chargingPointMock.Object)).Returns(newChargingPointId);
            // _repositoryFacadeMock.Setup(r => r.GetChargingPointById(newChargingPointId)).Returns(createdChargingPoint);

            ChargingPointManager chargingPointManager = new ChargingPointManager(_repositoryFacadeMock.Object);
            int retrievedChargingPoint = chargingPointManager.RegisterChargingPoint(_chargingPointMock.Object);

            _chargingPointMock.VerifyAll();
            _repositoryFacadeMock.VerifyAll();
            Assert.AreEqual(newChargingPointId, retrievedChargingPoint);
        }

        #region Helpers
        public ChargingPoint CreateChargingPointWithSpecificId(int chargingPointId) 
        {
            return new ChargingPoint()
            {
                Id = chargingPointId,
                Name = "Punta del Este",
                Region = new Region()
                {
                    Id = 3,
                    Name = "Metropolitana"
                },
                Description = "Descripcion...",
                RegionId = 3,
            };
        }
        
        #endregion
    }
}