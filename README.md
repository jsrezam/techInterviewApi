# Installation Guide 

This application works at the front-end level on top of Angular framework. At the back-end level, it works with an API built on the .NET 5 platform that interacts with a PostgreSQL database. 

# Data Base Section:  

It is necessary to have a PostgreSQL instance configured and running on your local machine. The application runs under the user "postgres" with the development password "Development". 

This connection string can be seen in the following file on the API solution <appsettings.Development.json> 

# Docker Hints for Setup Database: 

You can run a container to set up and run a new PostgreSQL instance with the credentials needed by the application already configured. 

# Commands:  

docker create --name postgres-dev -e POSTGRES_PASSWORD=Development -p 5432:5432 postgres:11.5-alpine 

docker start postgres-dev 

# Api Code Source: 

The code source is in the following GitHub repository: 

https://github.com/jsrezam/techInterviewApi.git 

In order to run the Api execute the following commands: 

dotnet build  

dotnet run  

Important: You must have .NET 5 in your local machine. 
