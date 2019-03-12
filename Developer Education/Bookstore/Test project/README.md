# Test project

## Setup

1. Follow the [instructions on how to set up a test project on Litium docs](https://docs.litium.com/documentation/get-started/setting_up_a_test_project)
    1. Name your new class library project _Litium.Accelerator.Tests_
    1. If you are using ReSharper there is no need to install an additional Xunit test runner
    1. REMEMBER TO SELECT THE TEST PROJECT AS DEFAULT PROJECT IN BEFORE INSTALLING PACKAGES IN PACKAGE MANAGER CONSOLE!
1. Copy _FoundationConnectionString_ from **Web.config** of the MVC project to **App.config** of the test project
1. On the docs site there is an example class called _SolutionTests_, add this to the test project
1. Run all tests in SolutionTests to verify that they are green and the setup is working

## Additional tests

1. Add the class `AuthorServiceRatingsDecoratorTests` to the test project
    1. Add a test that verifies that the decorator adds ratings to book titles according to the logic you implemented in the [Author service decorator](../Author%20service%20decorator) task
    1. A finished example is avaliable in the _Resources_-folder
1. When you try to run your test after adding a reference to the _Litium.Accelerator_ project your will likely get the error described in the _Troubleshooting_-section on the unit test page on docs
    1. The easiest solution to get these classes here is to install the full Litium web-release, install the nuget package `Litium.Web.Setup.Complete` in the test project
1. Run your tests again and verify that they execute properly    

> Tip: To enable logging in test project make sure NLog.config in the root of the test project is set to _copy to output directory_ on build, also note log file path will be relative to the **/bin** directory of the testproject.


## Optional extra tasks

1. Write tests on everything!

