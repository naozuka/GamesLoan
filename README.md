# GamesLoan
 Web API for Games Loan. Using C# .NET Core, DDD (Domain Driven Design), SOLID Principles, Repository Pattern, EF Core with SQL Server, JWT Authetication, Unit Tests, Integration Tests with in memory database, Swagger docs and Docker Compose.

Getting Started
---------------

You must have Docker installed on your System for running this project. 


Run this in root folder for building the project:
```
docker-compose build
```

And then run with:
```
docker-compose up
```

The API is configured on port 8000, but you can change in docker-compose.override.yml if needed.

You can use swagger docs to see all the endpoints [http://localhost:8000/swagger/index.html](http://localhost:8000/swagger/index.html).

To quickly see if it's working, you can run in your browser [http://localhost:8000/api/test](http://localhost:8000/api/test)

Testing with Postman
--------------------
You can import the file GamesLoan.postman_collection.json from root of the project into your Postman. 

After importing, you must add an environment variable called baseurl. Set the default value to http://localhost:8000 unless you changed in docker-compose.override.yml.

There is a folder Tests where you can test all the endpoints at once.

To test individually, you must create a new login and then authenticate. Then you can run all the others endpoints.
