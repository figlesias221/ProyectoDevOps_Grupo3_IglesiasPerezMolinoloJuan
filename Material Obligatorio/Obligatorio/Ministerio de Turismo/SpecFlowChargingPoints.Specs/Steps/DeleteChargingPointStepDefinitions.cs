using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using MinTur.WebApi.Controllers;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowChargingPoints.Specs.Steps
{
    [Binding]
    public sealed class DeleteChargingPointStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private ChargingPoint _chargingPoint;
        private DbContext _dbContext;
        private RepositoryFacade _repositoryFacade;
        private ChargingPointManager _chargingPointManager;
        private ChargingPointController _chargingPointController;
        
        public DeleteChargingPointStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _chargingPoint = new ChargingPoint()
            {
                Id = 1111,
                Name = "PDE",
                Direction = "Punta del Este",
                Description = "Sunny",
                RegionId = 1
            };
            _dbContext  = ContextFactory.GetNewContext(ContextType.Memory);
            _dbContext.Database.EnsureDeleted();
            _repositoryFacade = new RepositoryFacade(_dbContext);
            _chargingPointManager = new ChargingPointManager(_repositoryFacade);
            _chargingPointController = new ChargingPointController(_chargingPointManager);
        }

        [Given("that the charging point with id (.*) exists")]
        public void GivenThatTheChargingPointWithIdExists(int id)
        {
            _dbContext.Set<Region>().Add(new Region(){ Id = 1, Name = "Punta Del Este" });
            _dbContext.SaveChanges();
            _repositoryFacade.StoreChargingPoint(_chargingPoint);
        }
        
        [When("the charging point with id (.*) is deleted")]
        public void WhenTheChargingPointWithIdIsDeleted(int id)
        {
            try
            {
                _chargingPointController.DeleteChargingPoint(id);
            }
            catch (Exception e)
            {
                _scenarioContext.Add("Exception_ChargingPoint_Delete", e);
            }
        }
    
        [Then("the charging point with id (.*) should no longer exist")]
        public void ThenTheChargingPointWithIdShouldNoLongerExist(int id)
        {
            Assert.Null(_dbContext.Set<ChargingPoint>().Where(c => c.FourDigit == id).FirstOrDefault());
        }

        [Given("that the charging point with id (.*) does not exist")]
        public void GivenThatTheChargingPointWithIdDoesNotExist(int id)
        {
            // do nothing
        }

        [Then("an exception explaining that the charging point with id (.*) does not exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdDoesNotExistsShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Delete"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(ResourceNotFoundException), exception.GetType());
            Assert.Equal($"Charging point with {id} does not exist and could not be deleted", exception.Message);
        }
    }
};