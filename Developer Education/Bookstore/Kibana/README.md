# Kibana

> To do this task you first need to complete the task **[Elastic search](../Elastic%20search)**

We can use [Kibana](https://www.elastic.co/products/kibana) to visualize data stored in Elastic search

## Setup Kibana

Kibana should already be setup in the **[Docker task](../Docker)** done before the **[Elastic search task](../Elastic%20search)**. Kibana is a web tool so all we need is a browser to open the tool.

1. First check status by opening http://localhost:5601/status in a browser, it should say _Kibana status is 
Green_
1. Click **Discover** in the left menu
    1. Here we first need to _Define index pattern_, write `litium*` as pattern to select all Litium search indexes
    1. Click next and in the _Time filter drop-down_ select _I don't want to use the Time filter_ and then click the _"Create index pattern"_-button
1. Experiment with different ways to explore and visualize the data in Elastic search
