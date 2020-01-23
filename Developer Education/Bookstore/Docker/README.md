# Docker

> To do this task you first need to complete the task [Installation](../Installation) 

* Redis is only avaliable in Litium version 7.3 and later
* Elasticsearch is only avaliable in Litium version 7.4 and later

## Setup

1. Install [Docker Desktop](https://docs.docker.com/docker-for-windows/install/) and make sure it is running
1. Download a copy of _docker-compose.yaml_ from the _Resources_-folder to your solution directory
1. Open a terminal or command window in your solution directory where you placed the _docker-compose.yaml_-file and run the command below to start three containers for Elastic, Kibana and Redis
    ```console
    docker-compose up
    ```

## Usage

* **Redis** is made avaliable at http://localhost:6379, see the [Redis task](../Redis) for more information
* **Elasticsearch** is made avaliable at http://localhost:9200, see the [Enable Elasticsearch task](../Enable%20Elasticsearch) for more information
* **Kibana** is made avaliable at http://localhost:5601, see the [Kibana task](../Redis) for more information

## Stop/Remove

Press `CTRL+C` to stop the containers and restart again with 
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

## FAQ

If you run in to There are in general three places to look for any issue that you experience during setup:

1. Litium event log - found as the file _litium.log_ in solution folder
1. Litium Elasticsearch log - found as the file _elastic.log_ in solution folder
1. Elasticsearch log in docker - Run the following command to get logs from the last minute (replace litium-elastic-demo with other container names if needed):
    ```console
    docker logs --since 1m litium-elastic-demo
    ```
    Additional documentation on options for `docker logs` can be found at https://docs.docker.com/engine/reference/commandline/logs/

### Conflicting ports

If you get an a port conflict error when you run the `docker-compose up` command then either change ports in the yaml-file or remove the existing container.

Error example:
> Bind for 0.0.0.0:6379 failed: port is already allocated

Get a list of existing containers (remove `-a` to only get running containers):
```console
docker ps -a
```

Use `docker stop` to stop a container
```console
docker stop litium-redis-demo
```

Or use the following command to stop all containers by combining the previous commands
```console
docker stop $(docker ps -a -q)
``` 

Start individual containers
```console
docker start litium-redis-demo
```

Remove ALL stopped containers
```console
docker system prune
```