# Test project

> To do this task you first need to complete the task [Installation](../Installation)

## Setup

The test framework is available as a [Litium lab on docs](https://docs.litium.com/partner/litium-labs/test-framework-for-litium-accelerator) (requires login with partner permissions).

If you installed your Litium Accelerator without the `-test`-attribute then start with the steps described in section [Adding the test project to an existing installation](#adding-the-test-project-to-an-existing-installation) below.

1. Copy the database connectionstring from `appsettings.json` of the Mvc-project to `appsettings.json` in the test project

1. The Shared folder setting is required, in `appsettings.json` of the Test-project, adjust _Litium.Folder_ to:

    ```JSON
    "Folder": {
        "Local": "../files/local",
        "Shared": "../files/shared"
    }
    ```

    This will make the files folder available in: `\Test\Litium.Accelerator.Test\bin\Debug`

1. Open the _Test Explorer_ window in _Visual Studio_ and click _Run all tests_

1. Log files that get updated during test runs are available in folder: `\Test\Litium.Accelerator.Test\bin\Debug\logs`

## Test the AuthorServiceRatingsDecorator

1. Add the class `AuthorServiceRatingsDecoratorTests` to the test project

1. Add a test that verifies that the decorator adds ratings to book titles according to the logic you implemented in the [Author service decorator](../Author%20service%20decorator) task

1. A finished example is avaliable in the [_Resources_-folder](Resources/AuthorServiceRatingsDecoratorTests.cs)

## Test the ErpPriceCalculatorDecorator

1. Write tests for `ErpPriceCalculatorDecorator` created in the [pricing rules task](../Pricing%20rules)

1. Adjust the test so that it runs as both anonymous and logged in user, use `SecurityContextService` to execute code with different user context

1. A finished example is avaliable in the [_Resources_-folder](Resources/ErpPriceCalculatorDecoratorTests.cs)

## Adding a test project to an existing installation

1. Create a new directory, for example `C:\Temp\TempAccelerator`, then start a PowerShell command prompt in that folder

1. Run the command below to create a new temporary Accelerator project with a test project:

    ```PowerShell
    dotnet new litmvcacc -test
    ```

1. Copy the project folder `\Test\Litium.Accelerator.Test` from the just temp-Accelerator to your main-Accelerator that you want to add tests to

1. Open your main-Accelerator in Visual Studio

1. Right-click the Solution in _Solution explorer_ and select _Add > Existing project_, then select the test project

1. Delete the TempAccelerator-folder created earlier containing the rest of the temporary Accelerator files that you do not need
