const { Given, Then, When } = require('@cucumber/cucumber')
const Stage2POCPage = require('../pageobjects/Stage2POCPage')

Given(/^I am on the home page$/, async () => {
  await Stage2POCPage.visit()
})

When(/^I click on start test$/, async () => {
  await Stage2POCPage.clickStartTest()
})

Then(/^I identify index of center to return$/, async () => {
  console.log('In Then problem method')
  await Stage2POCPage.validateIndex()
})
