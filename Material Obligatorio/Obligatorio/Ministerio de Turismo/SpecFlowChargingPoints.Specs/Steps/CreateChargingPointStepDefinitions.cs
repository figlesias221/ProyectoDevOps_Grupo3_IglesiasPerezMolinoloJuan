using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.Domain.BusinessEntities;
using MinTur.Exceptions;
using MinTur.Models.In;
using MinTur.WebApi.Controllers;
using TechTalk.SpecFlow;
using Xunit;
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace SpecFlowChargingPoints.Specs.Steps
{
    [Binding]
    public sealed class CreateChargingPointStepDefinitions
    {
        private ScenarioContext _scenarioContext;
        private ChargingPointIntentModel _chargingPointModel;
        private DbContext _dbContext;
        private RepositoryFacade _repositoryFacade;
        private ChargingPointManager _chargingPointManager;
        private ChargingPointController _chargingPointController;
        
        public CreateChargingPointStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _chargingPointModel = new ChargingPointIntentModel();
            _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
            _dbContext.Database.EnsureDeleted();
            _repositoryFacade = new RepositoryFacade(_dbContext);
            _chargingPointManager = new ChargingPointManager(_repositoryFacade);
            _chargingPointController = new ChargingPointController(_chargingPointManager);
        }
        
        [Given(@"I have provided (.*) as Description")]
        public void GivenIHaveProvidedAsDescription(string description)
        {
            _chargingPointModel.Description = description;
        }

        [Given(@"I have provided (.*) as Direction")]
        public void GivenIHaveProvidedAsDirection(string direction)
        {
            _chargingPointModel.Direction = direction;
        }

        [Given(@"I have provided (.*) as Name")]
        public void GivenIHaveProvidedAsName(string name)
        {
            _chargingPointModel.Name = name;
        }
        
        [Given(@"I have provided (.*) as RegionId")]
        public void GivenIHaveProvidedAsRegionId(int id)
        {
            _chargingPointModel.RegionId = id;
        }
        
        [Given(@"the region with Id (.*) exists")]
        public void GivenTheRegionWithIdExists(int id)
        {
            _dbContext.Set<Region>().Add(new Region(){ Id = id, Name = "Punta Del Este" });
            _dbContext.SaveChanges();
        }

        [When(@"the charging point with Id (.*) is added")]
        public void WhenTheChargingPointWithIdIsAdded(int id)
        {
            try
            {
                _chargingPointModel.Id = id;
                _chargingPointController.CreateChargingPoint(_chargingPointModel);
            }
            catch (Exception e)
            {
                _scenarioContext.Add("Exception_ChargingPoint_Add", e);
            }
        }

        [Then(@"the charging point with Id (.*) should exist")]
        public void ThenTheChargingPointWithIdShouldExist(int id)
        {
            Assert.NotNull(_dbContext.Set<ChargingPoint>().Where(c => id == c.FourDigit));
        }

        [Then("a long name exception for the charging point with Id (.*) should be thrown")]
        public void ThenALongNameLengthExceptionForTheChargingPointShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Invalid charging point name - only alphanumeric and up to 20 characters", exception.Message);
        }
        
        [Then("a long description exception for the charging point with Id (.*) should be thrown")]
        public void ThenALongDescriptionLengthExceptionForTheChargingPointShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Invalid description - only up to 60 characters", exception.Message);
        }
        
        [Then("a long direction exception for the charging point with Id (.*) should be thrown")]
        public void ThenALongDirectionLengthExceptionForTheChargingPointShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Invalid direction - only up to 30 characters", exception.Message);
        }
        
        [Then("a long id exception for the charging point with Id (.*) should be thrown")]
        public void ThenALongIdLengthExceptionForTheChargingPointShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Id must be a 4 digit number", exception.Message);
        }
        
        [Then(@"an exception explaining that the charging point with Id (.*) is not valid should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdIsNotValidShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Invalid charging point name - only alphanumeric and up to 20 characters", exception.Message);
        }
        

        [Then(@"an exception explaining that the Region with id (.*) does not exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheRegionWithIdDoesNotExistsShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(ResourceNotFoundException), exception.GetType());
            Assert.Equal("Could not find specified region", exception.Message);
        }
        
        [Then("a non-numeric id exception for the charging point with Id (.*) should be thrown")]
        public void ThenANonNumericIdExceptionShouldBeThrown(int id)
        {
            Exception exception = (Exception) _scenarioContext["Exception_ChargingPoint_Add"];
            Assert.NotNull(exception);
            Assert.Equal(typeof(InvalidRequestDataException), exception.GetType());
            Assert.Equal("Id must be 4 digit and numeric", exception.Message);
        }
    }
}