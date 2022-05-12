using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MinTur.BusinessLogicInterface.ResourceManagers;
using MinTur.Domain.BusinessEntities;
using MinTur.Models.Out;
using System.Collections.Generic;
using MinTur.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using MinTur.Models.In;
using MinTur.Domain.SearchCriteria;

namespace MinTur.WebApi.Test.Controllers
{
    [TestClass]
    public class ChargingPointControllerTest
    {
        private List<ChargingPoint> _chargingPoints;
        private List<ChargingPointBasicInfoModel> _chargingPointsModel;
        private Mock<IChargingPointManager> _chargingPointManagerMock;

        #region SetUp
        [TestInitialize]
        public void SetUp()
        {
            _chargingPoints = new List<ChargingPoint>();
            _chargingPointsModel = new List<ChargingPointBasicInfoModel>();
            _chargingPointManagerMock = new Mock<IChargingPointManager>(MockBehavior.Strict);

            LoadChargingPoints();
            LoadChargingPointsModels();
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
        private void LoadChargingPointsModels()
        {
            foreach (ChargingPoint chargingPoint in _chargingPoints)
            {
                _chargingPointsModel.Add(new ChargingPointBasicInfoModel(chargingPoint.Id));
            }
        }
        #endregion


        [TestMethod]
        public void CreateChargingPointCreatedAtTest()
        {
            ChargingPointIntentModel chargingPointIntentModel = CreateChargingPointIntentModel();
            ChargingPoint expectedChargingPoint = CreateChargingPoint();

            _chargingPointManagerMock.Setup(t => t.RegisterChargingPoint(chargingPointIntentModel.ToEntity())).Returns(expectedChargingPoint.Id);
            ChargingPointController chargingPointController = new ChargingPointController(_chargingPointManagerMock.Object);

            IActionResult result = chargingPointController.CreateChargingPoint(chargingPointIntentModel);
            CreatedResult createdResult = result as CreatedResult;

            _chargingPointManagerMock.VerifyAll();
            Assert.IsTrue(createdResult.StatusCode == StatusCodes.Status201Created);
            Assert.AreEqual(new ChargingPointBasicInfoModel(expectedChargingPoint.Id), createdResult.Value);
        }

        #region Helpers
        public ChargingPointIntentModel CreateChargingPointIntentModel()
        {
            return new ChargingPointIntentModel()
            {
                Name = "Punta del este",
                Description = "Descripcion...",
                RegionId = 3,
                CategoriesId = new List<int>() { 1, 3, 84 }
            };
        }
        public ChargingPoint CreateChargingPoint()
        {
            return new ChargingPoint()
            {
                Id = 1,
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