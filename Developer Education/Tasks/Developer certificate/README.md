# Developer certificate

The first thing you need to do is to create a local certificate that will allow the Docker containers to communicate over `https`, additional details on this task can be found on [Litium docs](https://docs.litium.com/documentation/get-started/custom-developer-certificate).

1. Download the file `localhost.config` from the [_Resources_-folder](Resources/localhost.config) to your computer.
1. Start a PowerShell-prompt in the folder where you downloaded `localhost.config` and execute the commands below in order (you can paste the entire script att once the to run all commands) to first create and and then install a certificate (press _Ok_ when prompted):

   ```PowerShell
   # 1. Get current folder
   $p=$PSScriptRoot; if ("" -eq $p) { $p = (Get-Location) };

   # 2. Generate certificate-file and a key-file
   docker run --rm -t -it -v "$($p):/data:rw" alpine/openssl `
       req -x509 `
       -nodes `
       -days 3650 `
       -newkey rsa:4096 `
       -keyout /data/generated-localhost.key `
       -out /data/generated-localhost.crt `
       -config /data/localhost.config `
       -subj "/CN=localhost"

   # 3. Generate a random password to use for the certificate pfx-file
   $s=([System.Guid]::NewGuid());

   # 4. Export a pfx-file containing the certificate and the key, protected by your generated password
   docker run --rm -t -it -v "$($p):/data:rw" alpine/openssl `
       pkcs12 -export `
       -out /data/generated-localhost.pfx `
       -inkey /data/generated-localhost.key `
       -in /data/generated-localhost.crt `
       -passout pass:$s

   # 5. Import the exported pfx file into user certificates on your computer
   dotnet dev-certs https --clean --import "$p/generated-localhost.pfx" --password $s

   # 6. Make the certificate "trusted" (to avoid certificate errors in your browser)
   dotnet dev-certs https --trust

   # 7. Cleanup by removing all generated files in current folder
   Remove-Item -Path "$($p)/generated-*" -Recurse -Force | Out-Null
   ```
