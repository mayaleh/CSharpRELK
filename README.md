# Description

## Instructions

1. In `/RELKstack` run

```sh
docker-compose up
```

2. Run C# app

### Info

- Kibana http://localhost:5601/
- RabbitMq ports: `15672`, `5672`
- Send log using terminal:

    ```sh
    curl -u guest:guest -X POST -H "Content-Type:application/json" -d '{"properties":{"content-type": "application/json"},"routing_key":"#.#.#","payload":"{\"Message\":\"custom message from terminal\"}","payload_encoding":"string"}' http://localhost:15672/api/exchanges/%2F/logging.application.serilog/publish
    ```

