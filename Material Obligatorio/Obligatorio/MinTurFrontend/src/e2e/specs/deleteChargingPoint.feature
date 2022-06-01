Feature: Tests Delete Charging Points

@deleteChargingPoint
  Scenario: Delete charging point ok
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    Given the charging point with id "9007" exists
    When I provide "9007" as Id
    When I click "deleteChargingPointBtn"
    Then I see the delete message "¡Éxito, punto de carga eliminado!"

@deleteChargingPoint
 Scenario: Delete non existing charging point
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    Given the charging point with id "4444" does not exist
    When I provide "4444" as Id
    When I click "deleteChargingPointBtn"
    Then I see an alert "Inténtalo nuevamente, no se encontró el recurso"

@deleteChargingPoint
 Scenario: Delete charging point invalid id
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1" as Id
    When I click "deleteChargingPointBtn"
    Then I see the delete error "Id debe tener 4 dígitos"
    
@deleteChargingPoint
 Scenario: Delete charging point empty id
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide " " as Id
    When I click "deleteChargingPointBtn"
    Then I see the delete error "Id debe tener 4 dígitos"