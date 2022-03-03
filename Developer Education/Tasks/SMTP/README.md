# Configure SMTP

> To do this task you first need to complete the [Installation task](../Installation).

## Setup

In the [Docker task](../Docker) that you did earlier, a container was started with the SMTP test application [MailHog](https://github.com/mailhog/MailHog).

Adjust your applications SMTP-setting to connect to it:

1. Find the **Litium:Accelerator:Smtp** setting in
`appsettings.json` and change it to:

    ```JSON
    "Accelerator": {
        "Smtp": {
            "Host": "host.docker.internal",
            "Port": 1025,
            "Password": "",
            "Username": "",
            "EnableSecureCommunication": false
        }
    }
    ```

1. A sender email address is required to send mail from the application
    1. In Litium backoffice, go to _Settings > Website > Websites_ and double-click your _Bookstore_-website
    1. Find the _"Sender email address"_-setting and add a valid email as value

## Test

1. Edit the user **admin** in the Customers-area in Litium backoffice
    1. Check the Settings-tab, if no template is set, select the _Person B2B_-template
    1. Then select the Properties-tab and set a value in the _Email_-field
    1. Log out
1. Click the login-link **on the public site**
    1. Click _Forgot password?_ and request a password to be sent to the email you set for the admin-user
1. Open MailHog in your browser at http://localhost:8025/ where you should have received a mail with instructions on how to reset your password.

If you have done the setup of [Payment and shipping](../Payment%20and%20shipping) you can also test the the order confirmation e-mail:

1. The Litium application will send a request to itself to render the order confirmation email, for this request to work some additional configuration is required.
    1. In _Backoffice > Settings > Globalization > Domain names_ double-click to edit the `bookstore.localtest.me`-domain. Set a value for the _HSTS max age setting_ (for example 100) to force requests to use `https`, otherwise the order confirmation mail will try using `http` and fail (in a production environment [this setting should be set to at least a year](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Strict-Transport-Security))

1. Place an order and confirm that the order confirmation mail is received in MailHog.

## Troubleshooting

* If no mails are received, first check for errors in the `litium.log` file.

* It may be required to [specify port for HTTPS redirects](https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-6.0&tabs=visual-studio#port-configuration). Add a new environment variable in the application container. In the `Dockerfile` in Visual Studio add the line below at line 7, right after the `"EXPOSE 443"`-line

    ```PowerShell
    ENV ASPNETCORE_HTTPS_PORT="5001"
    ```
