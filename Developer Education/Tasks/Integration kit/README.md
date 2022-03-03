# Integration kit - LITIUM 7 ONLY

> To do this task you first need to complete the task [Installation](../Installation)

## Preparations

1. [Download integration kit from docs](https://docs.litium.com/add-ons/connectors/litium-integration-kit-for-litium-7)
    1. You will need to click _Buy_ to download, fill out your information and in the field _Use on_ write _Developer education_
1. The downloaded zip has a _src_-folder with 3 projects.
    1. The `Litium.Integration.Service` project is used to run integration kit as a standalone windows service, but the easiest way to run integration kit jobs is to schedule and run these in the Litium website which you will be doing here so skip this project
    1. Copy the folders `Litium.Integration.Implementation` and `Litium.Integration.XmlTypeConverters` into the _src_-folder of your Litium project
1. In Visual Studio
    1. Right-click the solution in Solution explorer, select _Add > Existing project..._ then locate `Litium.Integration.Implementation.csproj` in the `Litium.Integration.Implementation`-folder that you just copied and add it to your solution
    1. In the same way add project `Litium.Integration.XmlTypeConverters.csproj` from the `Litium.Integration.XmlTypeConverters`-folder

## Setup pricelist import

In `Litium.Integration.Implementation.Imports` you will find that integration kit comes with working example imports for media, pricelists, products and stock balance. These imports work with files that match those found in the _Samples_-folder. Integration kit is a source code addon so it is expected that you will need to change/add imports to match what you want to import.

In this example you will just setup a price import but all imports work the same way.

1. To run the integraion from the website it will need a reference to the integrations-project. Right click References for the Mvc-project in solution explorer, select _Add reference..._ and add a reference to the `Litium.Integration.Implementation`-project
1. Schedule the price import job in `Web.config` of the Mvc-project, add this line to the `<scheduledTasks>`-section to schedule it to run every minute:

    ```XML
    <scheduledTask type="Litium.Integration.Implementation.Imports.PriceListImport, Litium.Integration.Implementation" startTime="00:01" interval="1m" />
    ```

1. In `Web.config` you also need to define the folder where Integration kit will be looking for new files to import, add the line below to `<appSettings>`-section of the `Web.Config`-file. An absolute path is required here so use the absolute path to the Files directory in your src-folder.

    ```XML
     <add key="IntegrationDirectory" value="[Absolute path to files directory]\IntegrationKitImports" />
    ```

1. Build and run the solution
    1. If you get build errors here it is likely that Integration kit and Litium installation reference different nuget package versions (for example `Could not load file or assembly 'Litium.Abstractions, Version=7.0.0.0` when version 7.1 is installed). To resolve this open nuget package manager for the solution and search for _litium_ on the _Consolidate_-tab. Resolve all version differences by installing the correct version in the integration projects.
1. If you look at the constructor of `Litium.Integration.Implementation.Imports.PriceListImport` you can see that it passes a foldername to its base-class constructor and in `DefaultFileImportBase` that folder is created as a subfolder of the `IntegrationDirectory` defined earlier. So if everything is done right you should get the folder `\Src\Files\IntegrationKitImports\PriceList` generated automatically within a minute when the job runs.

## Import a pricelist

1. Looking at `PrepareProcess` of `PriceListImport` you can see that the import expects a filename that match the id of a pricelist in Litium. You can see the Id of your pricelist by editing it in PIM in Litium backoffice.
1. Make a copy of the file `\Src\Litium.Integration.Implementation\Samples\PriceList\iSEK.txt` and rename the copy to _[your pricelists id].txt_
1. Open your new file and note that it is tab-separated with articlenumber, price and quantity (quantity is optional but is used when working with  with [tier pricing](https://docs.litium.com/documentation/litium-documentation/products/price-lists-and-calculations))
1. View any product in PIM and select the price-tab
1. Modify your new textfile and set articlenumbers from the price-tab with new prices
1. Copy the file to `\Src\Files\IntegrationKitImports\PriceList` and wait for 1 minute
1. If all goes well with the import the file will be moved to a new _Archive_-folder that is now created and the price of the variats should be changed in PIM.
1. If the import is not working review your event log that might have information on what goes wrong

## Additional resources

Additional documentation can be found on Docs at <https://docs.litium.com/documentation/add-ons/integration/litium-integration-kit>
