# Litium Developer Education Presentation 

The slides are created with [Remark](https://remarkjs.com/).

## FAQ

### Running the presentation

The following shortcuts are avaliable when running the presentation. All of these shortcuts can also be seen during a presentation by pressing H or ?
```
* h or ?: Toggle the help window
* j: Jump to next slide
* k: Jump to previous slide
* b: Toggle blackout mode
* m: Toggle mirrored mode.
* c: Create a clone presentation on a new window
* p: Toggle PresenterMode
* f: Toggle Fullscreen
* t: Reset presentation timer
* <number> + <Return>: Jump to slide <number>
```
From: https://github.com/gnab/remark/wiki/Keyboard-shortcuts

### Working with the presentation

* [Remark Wiki](https://github.com/gnab/remark/wiki)
* Remark renders HTML with [marked.js](https://github.com/markedjs/marked) wich implement [Github flavored markdown](https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax).

### Run the presentation on a local machine (Offline)

1. Checkout the education repository or download the files as zip.
1. Start a command prompt or terminal in the _Presenation_-folder
1. run the command `npm install` to install required node modules
1. run the command `npm start` to start the presenation website
1. the site is avaliable at http://localhost:3000

If you need to run the presentation offline it needs to be set up in a local web server, for example [http-server](https://www.npmjs.com/package/http-server).

### Deployment

> This section is only targeted to Litium staff deploying the documentation to public hosting.

Deployment is done as described in https://docs.microsoft.com/en-us/azure/app-service/app-service-web-get-started-nodejs

1. Install the [Azure App Service extension](vscode:extension/ms-azuretools.vscode-azureappservice) in VS Code
1. Connect to the Azure app service where the documentation slides are hosted
1. Publish the site as described in above link

