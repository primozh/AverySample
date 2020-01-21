# Avery Dennison sample

## Build and run

Project is build using .NET core framework. 

### Docker
The most convinient way to run it is with Docker. Just open your command prompt and verify that docker is up and running.

`docker version`

You can manually build and run container using: 

```bash
docker build -t sample-app .
docker run -p 5000:80 --name sample-app sample-app
```

Or, if docker-compose is installed on your machine use this:
```bash
docker-compose up
```

### dotnet cli

You can run service directly.
```bash
dotnet run
```

## OpenApi

OpenApi specs are available via Swagger UI: `http://<host>:<port>/swagger` e.g. [http://localhost:5000/swagger](http://localhost:5000/swagger).

## Notes

This app is fairly simple and implemented in a rather dummy way.
It uses an in-memory database, so data is lost on every restart. Also stats are calculated on the fly and no cache is used.
Error handling is not properly implemented, code style and management could be better and more C#-like. Tests are currently not included due to time constraints.
Better way to tackle this problem is by using time series database with live data aggregation and processing (DW-like functionalities).
Also, additional constraints and data validation should be done to further prevent non parsable and consequently corrupted data.

Time taken: approx. 13h (refreshing C#, ASP.NET, EF Core how-to, API, coding, testing).