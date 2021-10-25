# Payment and shipping

From Litium version 8 all payment and shipping providers are set up as separate [Litium Apps](https://docs.litium.com/documentation/litium-apps).

To be able to place orders in your site you will need to configure a payment provider and a shipping provider.

## Prepare

Download `direct-payment-config.json` and `direct-shipment-config.json` from the [_Resources_-folder](Resources) to your computer.

## Add payments

An app container for [Direct payment](https://docs.litium.com/documentation/litium-apps/direct-payment) was created earlier when you did the [Docker task](../Docker).

Follow these steps to create and configure the app:

1. To create the app just navigate to the Direct payment app at [https://host.docker.internal:10011](https://host.docker.internal:10011), this will open the installation view in backoffice of your Litium application:
    ![Alt text](Images/payment-app-created.jpg "Docker build menu")
1. Click install in the above view
1. In the next view click _Select file_ under _Configuration_ and select the file `direct-payment-config.json` that you downloaded earlier.
1. Click save

## Add shipping

An app container for [Direct shipment](https://docs.litium.com/documentation/litium-apps/direct-shipment) was created earlier when you did the [Docker task](../Docker).

Follow these steps to create and configure the app:

1. To create the app just navigate to the Direct payment app at [https://host.docker.internal:10021](https://host.docker.internal:10021), this will open the installation view in backoffice of your Litium application:
    ![Alt text](Images/shipment-app-created.jpg "Docker build menu")
1. Click install in the above view
1. In the next view click _Select file_ under _Configuration_ and select the file `direct-shipment-config.json` that you downloaded earlier.
1. Click save

## Configure channel

In the control panel in Litium backoffice select _Globalization > Channels_

1. Edit your _Bookstore_-channel
1. Select the _Countries_-tab
1. Sweden should already be available otherwise add it as country
1. Click _Add payment method_ and select _DirectPayment:DirectPay_
1. Click _Add shipping method_ and select both _DirectShipment:expressPackage_ and _DirectShipment:standardPackage_
1. Click save

## Try it out

1. Navigate to your public website
1. Add some items in cart and navigate to checkout
1. Verify that both delivery and payment mehods are available in checkout
