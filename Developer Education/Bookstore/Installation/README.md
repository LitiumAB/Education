# Install Litium Accelerator

1. Prepare
    1. Assert that you have [configured Litium NuGet feed](https://docs.litium.com/download/litium-nuget-feed)
1. Download
    1. Login to docs.litium.com and go to _Download_ 
    1. Download the latest version of Accelerator Mvc, if you do not see the Accelerator download your profiles does not have download permission
    1. Unzip the directory to a local folder where you will be working with the solution
1. Install
    1. Open the Accelerator.sln in Visual Studio
    1. In Package Manager Console, run the command `Update-Package –ReInstall`
    1. Git repo _(Optional to log and possibly revert all changes)_
        1. Learning git is not in the scope of this training so if you are not sure about how to do this just skip
        1. Init a git repo in the folder holding your solution. In this way you will be able to to document progress and revert change ()
        1. A `.gitignore`-file can be found in the `\Resources`-folder
1. Setup accelerator
    1. Wait for nuget installation to complete
    1. Right-click _Litium.Accelerator.Mvc_-project and select _Set as StartUp Project_
    1. Launch the site with `Ctrl+F5`, this will start the site and automatically direct you to the backoffice login at _http://[your domain]**/Litium**_
    1. Login to Litium Backoffice using your local windows account (example: \my.name@litium.com - _note that the backslash before loginname is required even if not connected to a domain, if you are on a domain it should be DOMAIN\my.name@litium.com_)
    1. Open _Control panel (cogwheel in top right corner) > Deployment > Accelerator_
        1. Set a site name, for example _Education_
        1. Set url, for example _education.localtest.me_ (by setting localtest.me as domain [it is not required to setup the domain in host-file](http://readme.localtest.me/))
        1. Assert that the box to create example products is checked
        1. Click **Import**
    1. Configure accelerator site to work on localhost domain
        1. Open _Control panel > Globalization > Domain names_
        1. Click _New_ and add **localhost**
        1. Open _Control panel > Globalization > Channels_ and edit your channel
        1. On _Domain URL_-tab add the _localhost_ domain as an _Alternative domain_
        1. Remove **/litium** from url to browse the public Accelerator website

Additional [installation instructions](https://docs.litium.com/documentation/litium-accelerators/install-litium-accelerator) can be found on Litium docs