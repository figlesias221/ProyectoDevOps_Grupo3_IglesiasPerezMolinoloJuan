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
        private readonly ChargingPoint _chargingPoint = new ChargingPoint()
        {
            Id = 1,
            Name = "PDE",
            Direction = "Punta del Este",
            Description = "Sunny",
            Region = new Region(){Id = 1, Name = "Punta Del Este"},
            RegionId = 1
        };

        private static readonly DbContext DbContext = ContextFactory.GetNewContext(ContextType.Memory);
        private readonly RepositoryFacade _repositoryFacade = new RepositoryFacade(DbContext);

        private ResourceNotFoundException _exception;
    
        public DeleteChargingPointStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    
        [Given("that the charging point with id (.*) exists")]
        public void GivenThatTheChargingPointWithIdExists(int id)
        {
            DbContext.Set<Region>().Add(new Region(){Id = 1, Name = "Punta Del Este"});
            _repositoryFacade.StoreChargingPoint(_chargingPoint);
        }
        
        [When("the charging point with id (.*) is deleted")]
        public void WhenTheChargingPointWithIdIsDeleted(int id)
        {
            try
            {
                ChargingPointManager chargingPointManager = new ChargingPointManager(_repositoryFacade);
                ChargingPointController controller = new ChargingPointController(chargingPointManager);
                
                controller.DeleteChargingPoint(id);
            }
            catch (ResourceNotFoundException e)
            {
                _exception = e;
            }
        }
    
        [Then("the charging point with id (.*) should no longer exist")]
        public void ThenTheChargingPointWithIdShouldNoLongerExist(int id)
        {
            Assert.Null(DbContext.Set<ChargingPoint>().Find(id));
        }

        [Given("that the charging point with id (.*) does not exist")]
        public void GivenThatTheChargingPointWithIdDoesNotExist(int id)
        {
            
        }

        [Then("an exception explaining that the charging point with id (.*) does not exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdDoesNotExistsShouldBeThrown(int id)
        {
            Assert.NotNull(_exception);
            Assert.Equal($"Charging point with {id} does not exist and could not be deleted", _exception.Message);
        }
    }
};