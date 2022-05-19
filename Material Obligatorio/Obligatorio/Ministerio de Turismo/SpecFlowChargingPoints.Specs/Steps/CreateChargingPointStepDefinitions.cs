using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MinTur.BusinessLogic.ResourceManagers;
using MinTur.DataAccess.Contexts;
using MinTur.DataAccess.Facades;
using MinTur.DataAccess.Repositories;
using MinTur.Domain.BusinessEntities;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowChargingPoints.Specs.Steps
{
    [Binding]
    public sealed class CreateChargingPointStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ChargingPoint _chargingPoint = new ChargingPoint();
        private static DbContext _dbContext = ContextFactory.GetNewContext(ContextType.Memory);
        private readonly RepositoryFacade _repositoryFacade = new RepositoryFacade(_dbContext);
    
        public CreateChargingPointStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        [Given(@"I have provided (.*) as Description")]
        public void GivenIHaveProvidedAsDescription(string description)
        {
            _chargingPoint.Description = description;
        }

        [Given(@"I have provided (.*) as Direction")]
        public void GivenIHaveProvidedAsDirection(string direction)
        {
            _chargingPoint.Direction = direction;
        }

        [Given(@"I have provided (.*) as Name")]
        public void GivenIHaveProvidedAsName(string name)
        {
            _chargingPoint.Name = name;
        }
        
        [Given(@"I have provided (.*) as RegionId")]
        public void GivenIHaveProvidedAsRegionId(int id)
        {
            _chargingPoint.RegionId = id;
        }
        
        [Given(@"the region with Id (.*) exists")]
        public void GivenTheRegionWithIdExists(int id)
        {
            _dbContext.Set<Region>().Add(new Region(){Id = 1, Name = "Punta Del Este"});
            _dbContext.SaveChanges();
        }

        [When(@"the charging point with Id (.*) is added")]
        public void WhenTheChargingPointWithIdIsAdded(int id)
        {
            ChargingPointManager chargingPointManager = new ChargingPointManager(_repositoryFacade);
            chargingPointManager.RegisterChargingPoint(_chargingPoint);
        }

        [Then(@"the charging point with Id (.*) should exist")]
        public void ThenTheChargingPointWithIdShouldExist(int id)
        {
            Assert.NotNull(_dbContext.Set<ChargingPoint>().Find(id));
        }

        [Then(@"an exception explaining that the charging point with Id (.*) is not valid should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdIsNotValidShouldBeThrown(int id)
        {
            _scenarioContext.Pending();
        }

        [When(@"the charging point with Name (.*) is added")]
        public void WhenTheChargingPointWithNameIsAdded(string nameName)
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the charging point with Id (.*) name should not be greater than (.*) characters should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdNameShouldNotBeGreaterThanCharactersShouldBeThrown(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the charging point with Id (.*) direction should not be greater than (.*) characters should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdDirectionShouldNotBeGreaterThanCharactersShouldBeThrown(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the charging point with Id (.*) description should not be greater than (.*) characters should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdDescriptionShouldNotBeGreaterThanCharactersShouldBeThrown(int p0, int p1)
        {
            _scenarioContext.Pending();
        }

        [Given(@"the charging point with Name (.*) already exists")]
        public void GivenTheChargingPointWithNamePdeAlreadyExists(string name)
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the charging point with Name (.*) already exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithNamePdeAlreadyExistsShouldBeThrown(string name)
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the charging point Name cannot be null should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointNameCannotBeNullShouldBeThrown()
        {
            _scenarioContext.Pending();
        }

        [Then(@"an exception explaining that the Region with id (.*) does not exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheRegionWithIdDoesNotExistsShouldBeThrown(int p0)
        {
            _scenarioContext.Pending();
        }
    }
}