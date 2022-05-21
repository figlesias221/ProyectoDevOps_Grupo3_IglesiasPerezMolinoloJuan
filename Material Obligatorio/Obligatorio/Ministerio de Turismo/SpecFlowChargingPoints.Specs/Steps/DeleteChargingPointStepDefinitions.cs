using TechTalk.SpecFlow;

namespace SpecFlowChargingPoints.Specs.Steps
{
    [Binding]
    public sealed class DeleteChargingPointStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
    
        public DeleteChargingPointStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    
        [Given("that the charging point with id (.*) exists")]
        public void GivenThatTheChargingPointWithIdExists(int id)
        {
            _scenarioContext.Pending();
        }
        
        [When("the charging point with id (.*) is deleted")]
        public void WhenTheChargingPointWithIdIsDeleted(int id)
        {
            _scenarioContext.Pending();
        }
    
        [Then("the charging point with id (.*) should no longer exist")]
        public void ThenTheChargingPointWithIdShouldNoLongerExist(int id)
        {
            _scenarioContext.Pending();
        }

        [Given("that the charging point with id (.*) does not exist")]
        public void GivenThatTheChargingPointWithIdDoesNotExist(int id)
        {
            _scenarioContext.Pending();
        }

        [Then("an exception explaining that the charging point with id (.*) does not exists should be thrown")]
        public void ThenAnExceptionExplainingThatTheChargingPointWithIdDoesNotExistsShouldBeThrown(int id)
        {
            _scenarioContext.Pending();
        }
    }
};