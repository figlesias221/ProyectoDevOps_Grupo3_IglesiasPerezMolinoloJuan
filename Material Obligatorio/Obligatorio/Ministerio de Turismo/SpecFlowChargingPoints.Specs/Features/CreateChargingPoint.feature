Feature: CreateChargingPoint
	Charging point creation

@mytag
Scenario: Create charging point
	Given I have provided TeslaPoint as Name
	And I have provided Buceo as Direction
	And I have provided Charge your tesla as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 1111 is added
	Then the charging point with Id 1111 should exist
	
@mytag
Scenario: Create charging point with name length greater than 20
	Given I have provided ThisIsAVeryLongNameWithMoreThan20Characters as Name
	And I have provided Buceo as Description
	And I have provided PDE as Direction
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 1111 is added
	Then a long name exception for the charging point with Id 1111 should be thrown
	
@mytag
Scenario: Create charging point with direction length greater than 30
	Given I have provided ThisIsALongDirectionThisIsALongDirectionThisIsALongDirectionLongDirection as Direction
	And I have provided TeslaPoint as Name
	And I have provided Charge your tesla as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 1111 is added
	Then a long direction exception for the charging point with Id 1111 should be thrown
	
@mytag
Scenario: Create charging point with description length greater than 60
	Given I have provided PDE as Direction
	And I have provided PDEStation as Name
	And I have provided LongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescriptionLongDescription as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 1111 is added
	Then a long description exception for the charging point with Id 1111 should be thrown
	
@mytag
Scenario: Create charging point with empty fields
	Given I have provided PDE as Direction
	And I have provided Sunny as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 1111 is added
	Then an exception explaining that the charging point with Id 1111 is not valid should be thrown
	
@mytag
Scenario: Create charging point with unexistent region
	Given I have provided PDE as Direction
	And I have provided PDE as Name
	And I have provided Sunny as Description
	And I have provided 2 as RegionId
	When the charging point with Id 1111 is added
	Then an exception explaining that the Region with id 1 does not exists should be thrown
	
@mytag
Scenario: Create charging point with non 4 digit id
	Given I have provided PDE as Direction
	And I have provided PDE as Name
	And I have provided Sunny as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 111111 is added
	Then a long id exception for the charging point with Id 111111 should be thrown
	
# id's no numéricos se son interpretados como 0 (es decir, null) cuando se parsea del json de la request
# al modelo de la API
@mytag
Scenario: Create charging point with non-numeric id
	Given I have provided TeslaPoint as Name
	And I have provided Buceo as Direction
	And I have provided Charge your tesla as Description
	And I have provided 2 as RegionId
	And the region with Id 2 exists
	When the charging point with Id 0 is added 
	Then a non-numeric id exception for the charging point with Id 0 should be thrown
	
