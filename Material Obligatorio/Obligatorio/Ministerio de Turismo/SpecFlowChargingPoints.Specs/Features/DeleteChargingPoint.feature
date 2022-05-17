Feature: DeleteChargingPoint
	Delete charging point

@mytag
Scenario: Delete existing charging point
	Given that the charging point with id 1 exists
	When the charging point with id 1 is deleted
	Then the charging point with id 1 should no longer exist
	
@mytag
Scenario: delete non existing charging point
	Given that the charging point with id 2 does not exist
	When the charging point with id 2 is deleted
	Then an exception explaining that the charging point with id 2 does not exists should be thrown