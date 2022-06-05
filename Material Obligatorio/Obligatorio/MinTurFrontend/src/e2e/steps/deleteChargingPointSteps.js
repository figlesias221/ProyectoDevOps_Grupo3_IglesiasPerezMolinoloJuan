'use strict';

var { Given } = require('cucumber');
var { When } = require('cucumber');
var { Then } = require('cucumber');

// Use the external Chai As Promised to deal with resolving promises in
// expectations
const chai = require('chai');
const chaiAsPromised = require('chai-as-promised');
chai.use(chaiAsPromised);
const expect = chai.expect;

Given(/^the charging point with id "([^"]*)" exists$/, async (id) => {
    await browser.driver.findElement(by.name("id")).sendKeys(id);
    await browser.driver.findElement(by.name("name")).sendKeys("prueba");
    await browser.driver.findElement(by.name("description")).sendKeys("descripcion");
    await browser.driver.findElement(by.name("direction")).sendKeys("direccion prueba");

    await browser.driver.findElement(By.css('mat-select')).click();
    await browser.driver.findElements(By.css('mat-option')).then(function(elems) {
        elems[0].click();
    });

    await browser.driver.findElement(by.name("createChargingPointBtn")).click()
});
    
Given(/^the charging point with id "([^"]*)" does not exist$/, async (id) => {
    
});

When(/^I provide "([^"]*)" as Id$/, async (id) => {
    await browser.driver.findElement(by.name("deleteInput")).sendKeys(id);
});

Then(/^I see the delete message "([^"]*)"$/, async (message) => {
    await browser.driver.sleep(1000);
    await browser.waitForAngular();
    expect(element(by.name("deleteResponseMsg")).getText()).to.eventually.equal(message);
});

Then(/^I see the delete error "([^"]*)"$/, async (message) => {
    await browser.driver.sleep(1000);
    await browser.waitForAngular();
    expect(element(by.name("deleteErrorMsg")).getText()).to.eventually.equal(message);
});

Then(/^I see an alert "([^"]*)"$/, async (message) => {
    await browser.driver.sleep(2500);
    var alertDialog = await browser.switchTo().alert();
    expect(alertDialog.getText()).to.eventually.equal(message);
    alertDialog.accept();
});