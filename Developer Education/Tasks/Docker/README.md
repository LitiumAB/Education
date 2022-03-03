# Docker

> To do this task you first need to complete the [Developer certificate task](../Developer%20certificate)

If you run in to problems during setup see the [Troubleshooting section below](#troubleshooting).

## Preparations

Check that you have completed the requirements below installed before you start.

1. Install [Docker Desktop](https://www.docker.com/products/docker-desktop) to run the containers for Litium Apps

1. [Configure access to Litium's Docker container images](https://docs.litium.com/documentation/get-started/litium-packages) so that you can download the required images

## Setup

1. Download a copy of _docker-compose.yaml_ from the [_Resources_-folder](Resources/docker-compose.yaml)
1. Open a terminal or command window in the directory where you placed the _docker-compose.yaml_-file
1. Execute the command below to create a certificate file (additional info can be found on [Litium docs](https://docs.litium.com/documentation/litium-apps)):

    ```PowerShell
    dotnet dev-certs https -ep ./data/https/localhost.pfx -p SuperSecretPassword
    ```

    1. **Optionally** replace _SuperSecretPassword_ with your own password, if you do you also need to replace the password where it is used in the `docker-compose.yaml`-file (in the configuration for _direct-payment_ and _direct-shipment_):

        ```PowerShell
        ASPNETCORE_Kestrel__Certificates__Default__Password=SuperSecretPassword # <-- TODO Replace
        ```

1. Run the command below to start all containers needed to run Litium locally

    ```console
    docker-compose up
    ```

### Containers started

The following containers gets started

| Container | Port | Related task | Info
| -- | -- | -- | -- |
| Dnsresolver | 53 | | Used as DNS by other containers to let the _localtest.me_-domain reach the out of the container to the host (your computer)
| Elasticsearch | 9200 | [Litium search task](../Litium%20search) |
| Synonym server | 9210 | [Litium search task](../Litium%20search) | Used by Elasticsearch to store synonyms
| Kibana | 5601 | [Kibana task](../Kibana) | Used to browse Elasticsearch index files
| Redis | 6379 |[Redis task](../Redis) |
| Sql server | 6379 |[Installation](../Installation) |
| Direct payment | 10011 | [Payment and shipping](../Payment%20and%20shipping) | Litium App
| Direct shipment | 10021 | [Payment and shipping](../Payment%20and%20shipping) | Litium App
| MailHog |8025|[Installation](../Installation)|Development/Test SMTP server made available on port 1025, read more about [MailHog on github](https://github.com/mailhog/MailHog)

## Stop/Remove

Press `CTRL+C` to stop the running containers and restart again with:

```console
docker-compose up
```

Or use the command below to stop and remove all containers in the compose-file:

```console
docker-compose down
```

## Read more

* [Litium documentation on Elasticsearch](https://docs.litium.com/documentation/architecture/search/elasticsearch/setup-and-configure-elasticsearch)
* [Elasticsearch in docker](https://www.elastic.co/guide/en/elasticsearch/reference/7.5/docker.html)
* [Kibana in docker](https://www.elastic.co/guide/en/kibana/current/docker.html)
* [Redis in docker](https://docs.microsoft.com/en-us/archive/blogs/uk_faculty_connection/containers-redis-running-redis-on-windows-with-docker)
* [SQL Server in docker](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/database-server-container)

## Troubleshooting

If you run in to problems here are three good places to look for information:

|Error|Try this|
|--|--|
|`docker-compose up` fails with error _Bind for 0.0.0.0:6379 failed: port is already allocated_|Either change ports in the yaml-file or remove the existing container occupying the port (see instcuctions on how to remove in _Useful docker commands_ below)|
|`docker-compose up` fails|Try moving the `docker-compose.yaml`-file into a different folder|

### Check the logs

1. Litium event log - found as the file _litium.log_ in folder `\Src\files\logs` (only available if the application can start)
1. Litium Elasticsearch log - found as the file _elasticsearch.log_ in folder `\Src\files\logs` (only available if the application can start)
1. Elasticsearch log in docker - see _Useful docker commands_ below for details on how to read the log

## Useful docker commands

### Container listing

Get a list of existing containers (remove `-a` to only get running containers):

```console
docker ps -a
```

### Read container logs

Run the following command to get logs from the last minute (replace litium-elastic-demo with other container names if needed):

```console
docker logs --since 1m [pid/name]
```

Optionally use the `-f` parameter to get live updates written to the console:

```console
docker logs -f [pid/name]
```

Additional documentation on options for `docker logs` can be found in [docker documentation](https://docs.docker.com/engine/reference/commandline/logs/).

### Stop container

Stop individual container

```console
docker stop litium-redis-demo
```

Or use the following command to stop all containers by combining the previous commands

```console
docker stop $(docker ps -a -q)
```

### Start container

Start individual containers

```console
docker start litium-redis-demo
```

### Remove container

Remove individual container:

```console
docker rm [pid/name]
```

Remove ALL containers:

```console
docker rm -f $(docker ps -aq)
```

Remove ALL stopped containers AND ALL unused resources:

```console
docker system prune
```
