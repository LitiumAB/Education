# Developer certificate

The first thing you need to do is to create a local certificate that will allow the Docker containers to communicate over `https`

Follow the instructions on [Litium docs](https://docs.litium.com/documentation/get-started/custom-developer-certificate) to:

1. Create a file named `localhost.config`.
1. Start a PowerShell-prompt in the folder where you created the `localhost.config`-file and execute the script from Litium docs (you can paste the entire script att once the to run all commands, press _Ok_ when prompted). The script will:

   1. Get current folder
   1. Generate certificate-file and a key-file
   1. Generate a random password to use for the certificate pfx-file
   1. Export a pfx-file containing the certificate and the key, protected by your generated password
   1. Import the exported pfx file into user certificates on your computer
   1. Make the certificate "trusted" (to avoid certificate errors in your browser)
   1. Cleanup by removing all generated files in current folder
