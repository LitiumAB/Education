# Move website from localhost to IIS

> To do this task you first need to complete the task [Move database to SQL Server](../Move%20database%20to%20SQL%20Server)

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
