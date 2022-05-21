Feature: DeleteChargingPoint
	Delete charging point

@mytag
Scenario: Delete existing charging point
	Given that the charging point with id 1111 exists
	When the charging point with id 1111 is deleted
	Then the charging point with id 1111 should no longer exist
	
@mytag
Scenario: delete non existing charging point
	Given that the charging point with id 2222 does not exist
	When the charging point with id 2222 is deleted
	Then an exception explaining that the charging point with id 2222 does not exists should be thrown