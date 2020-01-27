# Move the database from Visual Studio to SQL Server

1. Pick database to attach
    * When we installed the accelerator in the [Installation task](../Installation) a database was created in the `\Src\Litium.Accelerator.Mvc\App_Data`-folder, that version can be used if your local SQL Server is version 2017 or later
    * If you have SQL Server 2016 you can use a back up that Litium distributes as a nuget-package which you can find in the `\packages\Litium.Setup.Core[VERSION]\tools\db`-folder 
        * Since this database is blank you will need to re-do any database work already done (like deploy accelerator and create blocks and pages) after startup if you select it.

1. Copy the `.mdf` and `.ldf` file of your selected db to a folder outside of your solution-directory (if the files are locked try closing Visual Studio)
1. Run SQL Server Management Studio as administrator and connect to your local instance
    * Either right click databases in left tree and select _Attach_, select and attach your selected db
    * ...or if you prefer to [attach using SQL](https://docs.litium.com/more/best-practices/tips-tricks/restore-db-from)
1. Modify `FoundationConnectionString` in `Web.config`, the connectionstring below can be used as template but replace values with what you configured in SQL Server, example: 
    ```XML
    <add name="FoundationConnectionString" connectionString="Data Source=(local)\SQL2017; Initial Catalog=LitiumEducationDB; Integrated Security=True; MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
    ```
1. Start your site to verify that it runs as before with your new database