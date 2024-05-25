# Dotnet App example for FirmaDB

A .Net MVC app based on Microsoft's [tutorial](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio-code) 

## Requirements

1. .Net framework installed on Windows

2. Entity Framework installed

## Initiate mvc .net app in an empty folder

```bash
dotnet new mvc
```

This will initialize and create a .NET MVC app. 

## Run the app

### From Command Prompt

```bash
dotnet build
```
 
This will show the url (link) where the application starts running. 

## Add Database package (SQL Server)

This allows us to connect to a database running locally from this app. 

### Create a local database

In your local database engine, create a database by the name `FirmDb`.

### Install SqlServer package 

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.11
```

### Define FirmDbContext and connect string
Create a file FirmDbContext.cs and add a connection string property in appsettings, and use this db context in Program.cs.

### Allow migrations 
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.11
dotnet ef migrations add InitialCreate
```

### Apply Migrations
```bash
dotnet ef database update
```

if all goes well, your local database `FirmDb` will have a table called EFMigrationsHistory. 
