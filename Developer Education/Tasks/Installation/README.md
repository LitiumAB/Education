# Install Litium Accelerator

> To do this task you first need to complete the [Docker task](../Docker)

Additional information related to the installation can be found on [Litium docs](https://docs.litium.com/documentation/litium-accelerators/install-litium-accelerator).

If you run into problems getting your site up and running see the [Troubleshooting section below](#troubleshooting).

## Preparations

Check that you have completed the _required_ requirements below before you start.

### Required

1. Litium is only distributed through NuGet, so first  [configure the Litium NuGet feed](https://docs.litium.com/documentation/get-started/litium-packages) (requires a [Litium Docs account](https://docs.litium.com/system_pages/createlitiumaccount) with partner privileges).
1. Install [Visual Studio](https://visualstudio.microsoft.com/) for the development
1. Install [SQL Server Management Studio](https://docs.microsoft.com/sv-se/sql/ssms/download-sql-server-management-studio-ssms) to manage the database

### Optional but recommended

1. Install [Baretail](https://www.baremetalsoft.com/baretail/) to monitor the Litium logfile during development
1. Install [Git](https://git-scm.com/) to make life easier

## Install the Accelerator

1. Create a directory on your computer where you want to keep your site, for example `C:\Temp\LitiumEducation\`.
1. Start a PowerShell command prompt **in your new directory**  and run the commands below:

    ```PowerShell
    # First install the Litium Accelerator template:
    dotnet new --install "Litium.Accelerator.Templates"

    # Make sure your new directory is selected:
    cd C:\Temp\LitiumEducation

    # Install a new Accelerator site using the Litium Accelerator template
    dotnet new litmvcacc
    ```

## OPTIONAL: Setup version control

For the education this is optional but using a Git-repo is always recommended during local development to be able to track and revert changes made.

> Note that Git help is not available during classroom training for time reasons.

1. Copy the `.gitignore`-file from the [_Resources_-folder](Resources/.gitignore) to your solution folder
1. Using Command-prompt or PowerShell
    1. Init a git repo in your solution-folder:

        ```PowerShell
        git init
        ```

    1. Add All files in the folder to Git

        ```PowerShell
        git add .
        ```

    1. Commit

        ```PowerShell
        git commit -m "Added Litium Accelerator"
        ```

1. Follow [Litiums recommended  branching strategy](https://docs.litium.com/documentation/litium-accelerators/install-litium-accelerator/maintain-the-litium-accelerator-solution) and setup a _Vanilla_-branch of the Accelerator for easier maintenance and upgrades.

## Configure a Litium database

1. In the previous [Docker task](../Docker) you started a container with _SQL Server_. If you did not modify the `docker-compose.yaml` file you can use SQL Server Management Studio to connect the that server with:

    * Server name: **127.0.0.1,5434**
    * Authentication: Select _SQL Server Authentication_
    * Login: **sa**
    * Password: **Pass@word**

1. [Create a new empty database](https://docs.microsoft.com/en-us/sql/relational-databases/databases/create-a-database?view=sql-server-ver15#SSMSProcedure) called **LitiumEducation**
1. Start a powershell prompt in the folder where you have the `Accelerator.sln`-file and run the commands below to set up the database with the [Litium db-tool](https://docs.litium.com/documentation/get-started/database-management):

    ```PowerShell
    # Run database migrations and configure the database
    dotnet litium-db update --connection "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=127.0.0.1,5434"

    # Create a new Litium backoffice admin user in the database with login admin/nimda
    dotnet litium-db user --connection "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=127.0.0.1,5434" --login admin --password nimda
    ```

1. Set the connectionstring in the `appsettings.json`-file in the Mvc-project:

    ```JSON
    "Litium": {
        "Data": {
            "ConnectionString": "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=127.0.0.1,5434",
    ```

    > IMPORTANT, in "real" projects you should not store sensitive information like this in code, see [safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows)

## Configure a files directory

Litium needs to store some data on disk (for example image uploads), find the _files_-setting in appsettings json and set it to:

```JSON
"Folder": {
  "Local": "../../files",
```

This will create a folder called _files_ in the folder where you have the `Accelerator.sln`-file.

## Configure custom domain

You need to run your site on a custom domain for other Litium Apps to work. Make the changes below to run your site on `bookstore.localtest.me` instead of `localhost`.

> By using a `localtest.me`-domain it is possible to use a custom domain without having to update the windows `hosts`-file. `Localtest.me` is a public domain that points to localhost, [click here to read more](http://readme.localtest.me/).

Adjust `Litium.Accelerator.Mvc\Properties\launchSettings.json`, replace _localhost_ and _port_ for the property `applicationUrl`:

```JSON
"applicationUrl": "https://bookstore.localtest.me:5001;http://bookstore.localtest.me:5000"
```

> * _localhost_ can actually still be used instead of _bookstore.localtest.me_, only the **port** is needed to connect.
> * Setting port to _5001_ makes it possible to reference the site in the coming tasks, if the original random port is used then connections defined in would have to be modified to match.

## Build and run

1. Right-click on the project `Litium.Accelerator.Mvc` and select **Set as startup project**
1. Press `Ctrl+F5` to build and run
1. If all goes well the site will start on a 404-page, add **/Litium** to the url to access Litium Backoffice login: <https://bookstore.localtest.me:5001/litium>
    1. If for some reason your page does not start please refer to the [Troubleshooting](#troubleshooting) section below
1. Login to Litium Backoffice using the admin account created earlier **(admin/nimda)**
    1. Open _Control panel (cogwheel in top right corner) > Deployment > Accelerator_
        1. Set _Name_ to _Bookstore_
        1. Set _Domain name_ to _bookstore.localtest.me_
        1. Click **Import**
            > IMPORTANT - Do not rebuild or restart the application while the installation is running, this may leave you with a partial installation. If this happens the easiest/fastest thing to do is to start over.
            >
            > _The import can take a couple of minutes, most of this time is spent importing data into Media. To view progress just open a new tab to <https://bookstore.localtest.me:5001/Litium/UI/media>, on this page you can see number of files increase in real time until it reaches about 350+ files._
    1. Navigate to <https://bookstore.localtest.me:5001/> to browse the public Accelerator website

> Note that the site will not list any products until [Litium search](../Litium%20search) is configured

## Troubleshooting

* **My application does not start?**

    Check the Litium application log if it contains additional information:  `\Src\Litium.Accelerator.Mvc\bin\Debug\litium.log`

* **I get nuget package errors when I build my solution?**

  * Validate and re-set your nuget credentials by following the steps below

    1. Login on Litium docs and navigate to <https://docs.litium.com/documentation/previous-versions/download> - if your account has download permissions this page should display a link to download the latest version 7 Accelerator:
            ![Alt text](Images/download-with-permissions.png "Download page with permissions")
        If the link is not visible please contact Litium support.
        1. If the link is visible try re-setting your nuget credentials:
            1. Close Visual Studio
            1. Remove current credentials using [nuget remove source](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-nuget-remove-source) by running the command below in a console/terminal:

                ```PowerShell
                dotnet nuget remove source Litium
                ```

            1. Re-add the NuGet credentials according to [instructions on Litium docs](https://docs.litium.com/documentation/get-started/litium-packages)
            1. Open Visual Studio and try again

* **I get error `invalid reference format` when I try to run my site**

  * You might have an invalid path to your solution file, verify that you have no spaces in the full path to your solution file, example:
    * Invalid: `c:\my litium site\Accelerator.sln`
    * Valid: `c:\mylitiumsite\Accelerator.sln`

* **I get error `The line number specified for #line directive is missing or invalid` when I try to run my site**

  * See [this forum post](https://forum.litium.com/t/getting-line-number-error-after-installing-visual-studio-2022/2302/2) for a solution).

* **Pressing `CTRL+F5` launches my browser but all I see is a 404-page**

  * This is expected behaviour until you have deployed an Accelerator website, just append _/litium_ to the URL and try again
