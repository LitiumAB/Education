# Install Litium Accelerator

## Prepare environment

Check that you have the requirements below installed before you start.

### Required

1. Litium is only available through NuGet, so first  [configure the Litium NuGet feed](https://docs.litium.com/documentation/get-started/litium-packages) (requires a [Litium Docs](https://docs.litium.com/) account with partner privileges).
1. Install [Visual Studio](https://visualstudio.microsoft.com/) for the development
1. Install [SQL Server](https://www.microsoft.com/sv-se/sql-server/sql-server-downloads) and [SQL Server Management Studio](https://docs.microsoft.com/sv-se/sql/ssms/download-sql-server-management-studio-ssms) for the database
1. Install [Docker Desktop](https://www.docker.com/products/docker-desktop) to run containers for Litium Apps

### Recommended

1. Install [Baretail](https://www.baremetalsoft.com/baretail/) to monitor the Litium logfile during development
1. Install [PaperCut](https://github.com/ChangemakerStudios/Papercut) for local email testing
1. Install [Git](https://git-scm.com/) to make life easier

## Installation

Additional [installation instructions](https://docs.litium.com/documentation/litium-accelerators/install-litium-accelerator) can be found on Litium docs.

1. Prepare a database
    1. Use [SQL Server Management Studio to create a new database](https://docs.microsoft.com/en-us/sql/relational-databases/databases/create-a-database?view=sql-server-ver15#SSMSProcedure) called _LitiumEducation_
1. Install Accelerator
    1. Create a directory where you want to keep your site, for example `C:\Temp\LitiumEducation\src` or similar.
    1. Start a PowerShell command prompt **in your new directory**  and run the commands below:
        ```PowerShell
        # First install the Litium Accelerator template:
        dotnet new --install "Litium.Accelerator.Templates"

        # Make sure your new directory is selected:
        cd C:\Temp\LitiumEducation

        # Install a new Accelerator site using the template:
        dotnet new litmvcacc

        # Run the Litium DB-tool to setup the database:
        dotnet litium-db update --connection "Pooling=true;Integrated Security=True;Database=LitiumEducation;Server=(local)"
        ```
1. Setup accelerator
    1. Open _Accelerator.sln_ in Visual Studio
    1. Add configurations in `appsettings.json` of the `Litium.Accelerator.Mvc`-project
        1. Set the connectionstring (the same that was used to setup database above)
            ```JSON
            "Litium": {
                ...
                "Data": {
                "ConnectionString": "Pooling=true;Integrated Security=True;Database=LitiumEducation;Server=(local)",
                    ...
            ```
        1. Set the _files_-directory where Litium can store files on disk
            ```JSON
            "Litium": {
                ...
                "Folder": {
                    "Local": "../../Files",
                    ...
            ```
    1. Right-click _Litium.Accelerator.Mvc_-project and select _Set as StartUp Project_
    1. Launch the site with `Ctrl+F5` to start the site
    1. If all goes well the site will start on a 404-page, add /Litium to the url to access Litium Backoffice login, example: https://localhost:12345/litium
    1. Login to Litium Backoffice using your local windows account (example: \my.name@litium.com - _note that the backslash before loginname is required even if not connected to a domain, if you are on a domain it should be DOMAIN\my.name@litium.com_)
    1. Open _Control panel (cogwheel in top right corner) > Deployment > Accelerator_
        1. Set _Name_ to _Bookstore_
        1. Set _Domain name_ to _localhost_
        1. Click **Import** (the Accelerator installation can take a couple of minutes)
    1. Remove **/litium** and everything after it from the url to browse the public Accelerator website

> Note that the site will have limited functionality until [Litium search](../Litium%20search) is configured

## Optional extra task: User secrets

It is recommended to not store configuration settings in version control and instead use [ASP.NET Core Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0).

We will move the connectionstring into a local user setting so that each developer in our project can use a unique connectionstring if needed.

1. Right-click the _Litium.Accelerator.Mvc_-project in Solution Explorer in Visual Studio and select _Manage User Secrets_ to open the `secrets.json`
1. Replace the content of the file with:
   ```JSON
    {
        "Litium": {
            "Data": {
            "ConnectionString": "Pooling=true;Integrated Security=True;Database=LitiumEducation;Server=(local)"
            }
        }
    }   
   ```
1. Remove the connectionstring from appsettings.json:
    ```JSON
    "Litium": {
        ...
        "Data": {
        "ConnectionString": null,
            ...
    ```

## Optional extra task: Version control

Using a Git-repo is always recommended during local development to be able to track and revert changes made. Git setup is not supported during classroom training for time reasons.

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
