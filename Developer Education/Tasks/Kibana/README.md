# Kibana

> To do this task you first need to complete the task **[Litium search](../Litium%20search)**

You can use [Kibana](https://www.elastic.co/products/kibana) to view the data stored in Elasticsearch

## Setup Kibana

Kibana is already running if you completed the **[Docker task](../Docker)** before the **[Litium search task](../Litium%20search)**. Kibana is a web tool so all you need is a browser to open the tool.

1. First check status by opening http://localhost:5601/status in a browser, it should say **Kibana status is Green**
1. Click **Discover** in the left menu
    1. _Define index pattern_: write `litium*` as pattern to select all Litium search indexes
    1. Click next and in the _Time filter drop-down_ select _I don't want to use the Time filter_ and then click the _"Create index pattern"_-button
    1. Click **Discover** in the left menu again to display index content
1. Experiment with different ways to explore and visualize the data in Elasticsearch, read more in the [Kibana quick start](https://www.elastic.co/guide/en/kibana/current/get-started.html).
