Feature: CreateChargingPoint
	Charging point creation

@mytag
Scenario: Create charging point
	Given I have provided TeslaPoint as Name
	And I have provided Buceo as Direction
	And I have provided Charge your tesla as Description
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	When the charging point with Id 1 is added
	Then the charging point with Id 1 should exist
	
@mytag
Scenario: Create charging point with name length greater than 20
	Given I have provided LongNameLongNameLongNameLoLongNamengNameLongNameLongName as Name
	And I have provided LongDirection as Description
	And I have provided PDE as Direction
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	When the charging point with Id 1 is added
	Then an exception explaining that the charging point with Id 1 name should not be greater than 20 characters should be thrown
	
@mytag
Scenario: Create charging point with direction length greater than 30
	Given I have provided ThisIsALongDirectionThisIsALongDirectionThisIsALongDirectionLongDirection as Direction
	And I have provided LongDirection as Name
	And I have provided LongDirection as Description
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	When the charging point with Id 1 is added
	Then an exception explaining that the charging point with Id 1 direction should not be greater than 30 characters should be thrown
	
@mytag
Scenario: Create charging point with description length greater than 60
	Given I have provided PDE as Direction
	And I have provided PDEStation as Name
	And I have provided LongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescription as Description
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	When the charging point with Id 1 is added
	Then an exception explaining that the charging point with Id 1 description should not be greater than 60 characters should be thrown
	
@mytag
Scenario: Create charging point with duplicate Name
	Given I have provided PDE as Direction
	And I have provided PDE as Name
	And I have provided Sunny as Description
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	And the charging point with Name PDE already exists
	When the charging point with Id 1 is added
	Then an exception explaining that the charging point with Name PDE already exists should be thrown
	
@mytag
Scenario: Create charging point with empty fields
	Given I have provided PDE as Direction
	And I have provided Sunny as Description
	And I have provided 1 as RegionId
	And the region with Id 1 exists
	When the charging point with Id 1 is added
	Then an exception explaining that the charging point Name cannot be null should be thrown
	
@mytag
Scenario: Create charging point with unexistent region
	Given I have provided PDE as Direction
	And I have provided PDE as Name
	And I have provided Sunny as Description
	And I have provided 1 as RegionId
	And the region with Id 1 does not exists
	When the charging point with Id 1 is added
	Then an exception explaining that the Region with id 1 does not exists should be thrown