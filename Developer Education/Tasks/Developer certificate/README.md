# Developer certificate

The first thing you need to do is to create a local certificate that will allow the Docker containers to communicate over `https`, additional details on this task can be found on [Litium docs](https://docs.litium.com/documentation/get-started/custom-developer-certificate).

1. Download the file `localhost.config` from the [_Resources_-folder](Resources/localhost.config) to your computer.
1. Start a PowerShell-prompt in the folder where you downloaded `localhost.config` and execute the commands below in order to first create and and then install a certificate (press _Ok_ when prompted):

    ```PowerShell
    $p=$PSScriptRoot; if ("" -eq $p) { $p = (Get-Location) };
    ```

    ```PowerShell
    docker run --rm -t -it -v "$($p):/data:rw" alpine/openssl `
        req -x509 `
        -nodes `
        -days 3650 `
        -newkey rsa:4096 `
        -keyout /data/generated-localhost.key `
        -out /data/generated-localhost.crt `
        -config /data/localhost.config `
        -subj "/CN=localhost"
    ```

    ```PowerShell
    $s=([System.Guid]::NewGuid());
    ```

    ```PowerShell
    docker run --rm -t -it -v "$($p):/data:rw" alpine/openssl `
        pkcs12 -export `
        -out /data/generated-localhost.pfx `
        -inkey /data/generated-localhost.key `
        -in /data/generated-localhost.crt `
        -passout pass:$s
    ```

    ```PowerShell
    dotnet dev-certs https --clean --import "$p/generated-localhost.pfx" --password $s
    dotnet dev-certs https --trust
    Remove-Item -Path "$($p)/generated-*" -Recurse -Force | Out-Null
    ```
