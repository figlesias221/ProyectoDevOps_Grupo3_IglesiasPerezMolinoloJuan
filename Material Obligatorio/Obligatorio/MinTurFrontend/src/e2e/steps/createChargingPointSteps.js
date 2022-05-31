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


Given(/^the user with email "([^"]*)" and password "([^"]*)" is logged in$/, async (email, password) => {
    await browser.get("http://localhost:4200/login");
    await browser.driver.findElement(by.name("email")).sendKeys(email);
    await browser.driver.findElement(by.name("password")).sendKeys(password);   
    await browser.driver.findElement(by.name("loginBtn")).click();
    
    await browser.wait(() => {
        return element(by.buttonText('Cerrar Sesion')).isPresent();
    });
});

When(
    /^I go to "([^"]*)"$/, async (url) => {
        await browser.get(url);
    }
);


When(
    /^I provide "([^"]*)" as "([^"]*)"$/,
    async (inputTextEntry, inputName) => {   
      await browser.driver.findElement(by.name(inputName)).sendKeys(inputTextEntry);
    }
);

When(
    /^I provide "([^"]*)" as region$/,
    async (regionPlace) => {   
      await browser.driver.findElement(By.css('mat-select')).click();
      await browser.driver.findElements(By.css('mat-option')).then(function(elems) {
        elems[regionPlace].click();
    });
      
    }
);

When(
    /^I click "([^"]*)"$/,
    async (buttonName) => {
        await browser.driver.findElement(by.name(buttonName)).click()
    }
);

Then(/^I see the message "([^"]*)"$/, async (message) => {
    await browser.driver.sleep(1000);
    await browser.waitForAngular();
    expect(element(by.name("responseMsg")).getText()).to.eventually.equal(message);
  });

