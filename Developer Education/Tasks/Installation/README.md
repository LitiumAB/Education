# Install Litium Accelerator

In this task we will set up a local Litium installation running in a Docker container.

> To do this task you first need to complete the [Docker task](../Docker)

Additional [installation instructions](https://docs.litium.com/documentation/litium-accelerators/install-litium-accelerator) can be found on Litium docs.

## Preparations

Check that you have completed the requirements below installed before you start.

### Required

1. Accessing Litium running inside a container requires a valid license. If you do not have a license already you can [request a demo-license from Litium Docs](https://docs.litium.com/support/request-license).
1. Litium is only distributed through NuGet, so first  [configure the Litium NuGet feed](https://docs.litium.com/documentation/get-started/litium-packages) (requires a [Litium Docs account](https://docs.litium.com/system_pages/createlitiumaccount) with partner privileges).
1. [Configure access to Litium's Docker container images](https://docs.litium.com/documentation/get-started/litium-packages) so that you can download the required images
1. Install [Visual Studio](https://visualstudio.microsoft.com/) for the development
1. Install [SQL Server Management Studio](https://docs.microsoft.com/sv-se/sql/ssms/download-sql-server-management-studio-ssms) to manage the database

### Optional but recommended

1. Install [Baretail](https://www.baremetalsoft.com/baretail/) to monitor the Litium logfile during development
1. Install [PaperCut](https://github.com/ChangemakerStudios/Papercut) for local email testing
1. Install [Git](https://git-scm.com/) to make life easier

## Install the Accelerator

1. Create a directory on your computer where you want to keep your site, for example `C:\Temp\LitiumEducation\`.
1. Start a PowerShell command prompt **in your new directory**  and run the commands below:

    ```PowerShell
    # First install the Litium Accelerator template:
    dotnet new --install "Litium.Accelerator.Templates"

    # Make sure your new directory is selected:
    cd C:\Temp\LitiumEducation

    # Install a new Accelerator site using the Litium Accelerator template:
    dotnet new litmvcacc
    ```

## Add docker support to the Accelerator

1. Configure Docker

    1. Open _Accelerator.sln_ in Visual Studio
    1. Right-click on the project `Litium.Accelerator.Mvc` and select **Add > Docker Support**
    1. In the project you now get a new file called `Dockerfile` that is specified to run the `aspnet:5.0`-image. You need to change it to use the `litium:net5`-image instead since you need some additional Litium requirements (node/Gdi-image scaling and some config):

        ```PowerShell
        # Replace this line at the top of the file:
        # FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
        # With this line:
        FROM registry.litium.cloud/runtime/litium:net5-latest AS base
        ```

        (You can find a modified `Dockerfile` in the [_Resources_-folder](Resources/Dockerfile)).
1. Add project configurations
    1. Edit the file `\Litium.Accelerator.Mvc\Litium.Accelerator.Mvc.csproj`, right before the closing `</Project>`-tag add the `<Target>`-tag below to configure the docker build:

        ```XML
            ...

                <Target Name="CreateDockerArguments" BeforeTargets="ContainerBuildAndLaunch">
                    <PropertyGroup>
                    <!-- Always pull to ensure that the latest image is used -->
                    <DockerfileBuildArguments>--pull</DockerfileBuildArguments>
                    
                    <!-- Define the parameters for files and folders to map on the host -->
                    <DockerLitiumFiles>$(MSBuildThisFileDirectory)../files</DockerLitiumFiles>
                    <DockerLitiumLogfile>$(DockerLitiumFiles)/litium.log</DockerLitiumLogfile>
                    <DockerLitiumElasticLogfile>$(DockerLitiumFiles)/elasticsearch.log</DockerLitiumElasticLogfile>
                    
                    <!-- Mappings so that files/logs inside the container is synced with 
                    files/folders foler on host
                    The Docker image used (defined in the Dockerfile) already contains 
                    the environment variable Litium__Folder__Local that defines files to 
                    be stored in app_data inside the container -->
                    <DockerfileRunArguments>$(DockerfileRunArguments) -v $(DockerLitiumFiles):/app_data:rw</DockerfileRunArguments>
                    <DockerfileRunArguments>$(DockerfileRunArguments) -v $(DockerLitiumLogfile):/app/bin/$(Configuration)/litium.log:rw</DockerfileRunArguments>
                    <DockerfileRunArguments>$(DockerfileRunArguments) -v $(DockerLitiumElasticLogfile):/app/bin/$(Configuration)/elasticsearch.log:rw</DockerfileRunArguments>

                    <!-- Configure the container to use the dnsresolver-container as DNS: -->
                    <DockerfileRunArguments>$(DockerfileRunArguments) --dns 192.168.65.2</DockerfileRunArguments>
                    </PropertyGroup>
                    
                    <!-- Make sure that the files/folders needed exists 
                    (otherwise the automatic volume-mapping will create directories 
                    instead of files) -->
                    <MakeDir Directories="$(DockerLitiumFiles)" Condition="!Exists('$(DockerLitiumFiles)')" />
                    <Touch Files="$(DockerLitiumLogfile)" AlwaysCreate="true" Condition=" !Exists('$(DockerLitiumLogfile)')" />
                    <Touch Files="$(DockerLitiumElasticLogfile)" AlwaysCreate="true" Condition=" !Exists('$(DockerLitiumElasticLogfile)')" />
                </Target>

            </Project>
            ...
        ```

## Configure a Litium database

1. In the previous [Docker task](../Docker) you started a container with _SQL Server_. If you did not modify the `docker-compose.yaml` file you can use SQL Server Management Studio to connect the that server with:
    - Server name: **127.0.0.1,5434**
    - Login: **sa**
    - Password: **Pass@word**
1. [Create a new empty database](https://docs.microsoft.com/en-us/sql/relational-databases/databases/create-a-database?view=sql-server-ver15#SSMSProcedure) called **LitiumEducation**
1. Start a powershell prompt in the folder where you have the `Accelerator.sln`-file and run the commands below to set up the database with the [Litium db-tool](https://docs.litium.com/documentation/get-started/database-management):

    ```PowerShell
    # Run database migrations and configure the database
    dotnet litium-db update --connection "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=kubernetes.docker.internal,5434"

    # Create a new Litium backoffice admin user in the database with login admin/nimda
    dotnet litium-db user --connection "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=kubernetes.docker.internal,5434" --login admin --password nimda
    ```

1. Set the connectionstring, Litium uses the standard .NET configuration system so select one of the options below to set the connection:
    - Set as environment variable in the application container. In the `Dockerfile` in Visual Studio add the line below at line 7, right after the `"EXPOSE 443"`-line

        ```PowerShell
        ENV Litium__Data__ConnectionString="Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=kubernetes.docker.internal,5434"
        ```

        You can find a modified `Dockerfile` in the [`_Resources_-folder](Resources/Dockerfile).
    - OR set it in the `appsettings.json` file in the Mvc-project:

        ```JSON
        "Litium": {
            "Data": {
                "ConnectionString": "Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=kubernetes.docker.internal,5434"
        ```

## Configure custom domain

You need to run our site on a custom domain for other Litium Apps to work. Make the changes below to run your site on `bookstore.localtest.me` instead of `localhost`.

By using a `[mysite].localtest.me`-domain it is possible to use a custom domain without having to update the windows `hosts`-file. `Localtest.me` is a public domain that points to localhost, [click here to read more](http://readme.localtest.me/).



Make the adjustment below to the Docker-section of `Litium.Accelerator.Mvc\Properties\launchSettings.json`

```JSON
// Replace with new domain:
//"launchUrl": "{Scheme}://{ServiceHost}:{ServicePort}",
"launchUrl": "{Scheme}://bookstore.localtest.me:{ServicePort}"
// Add defined ports for the application that we can connect to later:
"httpPort": 5000,
"sslPort": 5001
```

## Add license

Select one of the options below to add your License to the installation:

- Add your `license.json`-file to the root of the Mvc-project
- OR set as environment variable in the application container.
  - Open the `license.json`-file and copy the license token value
  - In the `Dockerfile` in Visual Studio add the line below at line 7, right after the `"EXPOSE 443"`-line

    ```PowerShell
    ENV Litium__License="eyJhbGciOiJSUzI1N...3RXeGMjZL05w"
    ```

    You can find a modified `Dockerfile` in the [`_Resources_-folder](Resources/Dockerfile)

## Build and run

1. Right-click on the project `Litium.Accelerator.Mvc` and select **Set as startup project**
1. In the Build-dropdown in the toolbar select **Docker**
    ![Alt text](Images/docker-in-build-menu.png "Docker build menu")
1. Press `Ctrl+F5` to build and run the application in a container
1. If all goes well the site will start on a 404-page, add **/Litium** to the url to access Litium Backoffice login, example: [https://bookstore.localtest.me:12345/litium](https://bookstore.localtest.me:12345/litium)
1. Login to Litium Backoffice using the admin account created earlier **(admin/nimda)**
    1. Open _Control panel (cogwheel in top right corner) > Deployment > Accelerator_
        1. Set _Name_ to _Bookstore_
        1. Set _Domain name_ to _localhost_
        1. Click **Import** (the Accelerator installation can take a couple of minutes)
    1. Remove **/litium** and everything after it from the url to browse the public Accelerator website

> Note that the site will not list any products until [Litium search](../Litium%20search) is configured

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
