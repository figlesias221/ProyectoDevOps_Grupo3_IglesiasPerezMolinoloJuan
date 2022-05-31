Feature: Tests Add Charging Points

@createChargingPoint1
  Scenario: Create charging point ok
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1234" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the message "¡Éxito, punto de carga agregado!"


@createChargingPoint2
  Scenario: Create charging point with non numeric id
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "TheId" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Id debe tener 4 dígitos"

@createChargingPoint3
  Scenario: Create charging point with non 4 digit id
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "123" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Id debe tener 4 dígitos"

@createChargingPoint4
  Scenario: Create charging point with name more than 20 caract
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1234" as "id"
    When I provide "AaaaaaaAaaaaaaAaaaaaaAaaaaaaAaaaaaaAaaaaaaAaaaaaa" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Nombre debe tener menos de 20 caract."


@createChargingPoint5
  Scenario: Create charging point with direction more than 30 caract
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1234" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Dirección debe tener menos de 30 caract."

@createChargingPoint6
  Scenario: Create charging point with description more than 60 caract
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1234" as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Descripcion debe tener menos de 60 caract."


@createChargingPoint7
  Scenario: Create charging point with empty id
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide " " as "id"
    When I provide "Cabo Polonio" as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Id debe tener 4 dígitos"

@createChargingPoint7
  Scenario: Create charging point with empty name
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1111" as "id"
    When I provide " " as "name"
    When I provide "Se ubica a 250km de la capital" as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Es necesario especificar un nombre"


@createChargingPoint8
  Scenario: Create charging point with empty direction
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1111" as "id"
    When I provide "Cabo polonio" as "name"
    When I provide "Se ubica a 250 km de la capital" as "description"
    When I provide " " as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Es necesario especificar una dirección"


@createChargingPoint9
  Scenario: Create charging point with empty description
    Given the user with email "matias@admin.com" and password "admin" is logged in
    When I go to "http://localhost:4200/admin/charging-point-create"
    When I provide "1111" as "id"
    When I provide "Cabo polonio" as "name"
    When I provide " " as "description"
    When I provide "Esteban Elena 3453" as "direction"
    When I provide "1" as region
    When I click "createChargingPointBtn"
    Then I see the error "Es necesario especificar una descripción"
