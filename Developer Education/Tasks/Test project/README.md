# Test project

> To do this task you first need to complete the task [Installation](../Installation)

Additional setup documentation is available in [Litium docs](https://docs.litium.com/documentation/get-started/setting_up_a_test_project)

## Setup

1. Copy the database connectionstring from `appsettings.json` of the Mvc-project to `appsettings.json` in the test project

1. Open the _Test Explorer_ window in _Visual Studio_ and click _Run all tests_

1. Log files that get updated during test runs are available in folder: `\Test\Litium.Accelerator.Test\bin\Debug\`

## Test the AuthorServiceRatingsDecorator

1. Add the class `AuthorServiceRatingsDecoratorTests` to the test project

1. Add a test that verifies that the decorator adds ratings to book titles according to the logic you implemented in the [Author service decorator](../Author%20service%20decorator) task

1. A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceRatingsDecoratorTests.cs)

## Test the ErpPriceCalculatorDecorator

1. Write tests for `ErpPriceCalculatorDecorator` created in the [pricing rules task](../Pricing%20rules)

1. Adjust the test so that it runs as both anonymous and logged in user, use `SecurityContextService` to execute code with different user context

1. A finished example is avaliable in the [_Resources_-folder](Resources/ErpPriceCalculatorDecoratorTests.cs)
