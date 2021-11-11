# Litium Developer Education Presentation 

The presentation is avaliable online at https://litiumdev-slides.svc.litiumlab.se

## FAQ

### Running the presentation

The following shortcuts from [remark wiki](https://github.com/gnab/remark/wiki/Keyboard-shortcuts) are avaliable when running the presentation.

* `h` or `?` : Toggle the help window with all shortcuts
* `j` : Jump to next slide
* `k` : Jump to previous slide
* `b` : Toggle blackout mode
* `m` : Toggle mirrored mode.
* `c` : Create a clone presentation on a new window
* `p` : Toggle PresenterMode
* `f` : Toggle Fullscreen
* `t` : Reset presentation timer
* `<number>` + `<Return>` : Jump to slide `<number>`

### Working with the presentation

The slides are created with [Remark](https://remarkjs.com/)

* [Remark Wiki](https://github.com/gnab/remark/wiki)
* Remark renders HTML with [marked.js](https://github.com/markedjs/marked) wich implement [Github flavored markdown](https://help.github.com/en/github/writing-on-github/basic-writing-and-formatting-syntax).
* Embedded diagrams are created and updated using [draw.io](https://app.diagrams.net/) - the diagrams are stored as `.png`-files but contain metadata making it possible to edit the diagram. Diagrams are stored in `\public\drawiodiagrams`

### Run the presentation on a local machine (Offline)

1. Checkout the education repository or download the files as zip
1. Start a command prompt or terminal in the _Presenation_-folder
1. run the command `npm install` to install required node modules (npm install might fail, then try `yarn install` which is more stable, [read more](https://legacy.yarnpkg.com/en/docs/getting-started))
1. run the command `npm start` to start the presenation website
1. the site is avaliable at http://localhost:3000

Additional setup information is avaliable at https://expressjs.com/en/starter/generator.html

### Deployment

> This section is only targeted to Litium staff deploying the documentation to public hosting.

The site is delivered to hosting as a docker image as defined in `Dockerfile`.

Follow the steps below, originally from https://nodejs.org/en/docs/guides/nodejs-docker-webapp/

#### Create docker image

1. Possibly first remove old version of the container

    ```console
    docker ps -a
    docker stop CONTAINERID
    docker rm CONTAINERID
    ```

1. Build the image

    ```console
    docker build -t litiumdev-slides .
    ```

1. Run to verify the container locally, the container runs a server at port 3000 that is made accessible on http://localhost:49160

    ```console
    docker run -p 49160:3000 -d litiumdev-slides
    ```

#### Deploy docker image to Litium Kubernetes hosting

1. Get DOMAIN/LOGIN/PWD to Litium Kubernetes
1. Login

    ```console
    docker login -u [LOGIN] -p [PWD] [DOMAIN]
    ```

1. Tag the remote and push image

    ```console
    docker tag litiumdev-slides [DOMAIN]/public/litiumdev-slides
    docker push [DOMAIN]/public/litiumdev-slides
    ```

1. Notify Litium to refresh site from latest image