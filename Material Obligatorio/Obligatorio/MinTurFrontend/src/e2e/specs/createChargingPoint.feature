Feature: Tests Add Charging Points

@createChargingPoint
  Scenario: Create charging point ok
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1234" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the message "¡Exito!"





