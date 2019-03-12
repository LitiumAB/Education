# Move website from localhost to IIS

## 1. Move database to SQL Server

1. Pick database to attach
    * When we installed the accelerator in previous step a database was created in the `\Src\Litium.Accelerator.Mvc\App_Data`-folder, that version can be used if your local SQL Server is version 2017 or later
    * If you have SQL Server 2016 you can use a back up that Litium distributes as a nuget-package which you can find in the `\packages\Litium.Setup.Core[VERSION]\tools\db`-folder 
        * Since this database is a new one you will need to re-deploy the accelerator after startup if you select it
1. Copy the `.mdf` and `.ldf` file of your selected db to a folder outside of your solution-directory (if the files are locked try closing Visual Studio)
1. Run SQL Server Management Studio as administrator and connect to your local instance
    * Either right click databases in left tree and select _Attach_, select and attach your selected db
    * ...or if you prefer to [attach using SQL](https://docs.litium.com/more/best-practices/tips-tricks/restore-db-from)
1. Adjust connectionstring
    1. Modify `FoundationConnectionString` in `Web.config` into something similar to match what you configured in SQL Server, example: `<add name="FoundationConnectionString" connectionString="Data Source=(local)\SQL2017; Integrated Security=True; Initial Catalog=LitiumEducationDB;" providerName="System.Data.SqlClient" />`
1. Start your site to verify that it runs as before with your new database

## 2. Setup website in IIS

1. Setup new website in IIS
    1. It should point to the `\Src\Litium.Accelerator.Mvc`-folder
    1. Select the same domain as you did when you deployed your accelerator (if you do not remember the domain it can be found in Control panel > Globalization > Domain names)
1. Adjust host-file (if you used a `localtest.me`-domain [this step can be skipped](http://readme.localtest.me/))
1. If you you get a database connection error in this step:
    1. If use used the connectionstring above with `Integrated Security=True` you can
        1. Setup a login in SQL Server and change connectionstring to provide credentials: `connectionString="Pooling=true;User Id=;Password=;Database=;Server=(local)\SQL2017"`
        1. OR edit advanced settings of your Application Pool in IIS and for _Identiy_ set custom account and login with your windows user
    1. If you are using a connectionstring with specified username and password:
        * Does your SQL Server have **SQL Server and Windows authentication** enabled in security settings?
        * Is the user specified not owner of the Litium database?
        * Is credential correct? Copy values from web.config and update the login in SQL Server
        
## Optional extra tasks

1. Add a self signed certificate so that the site can be accessed using https
1. Add an additional domain and create a separate channel using that domain
    1. Remember to connect it to your website and publish at least the startpage of the website to that channel.
