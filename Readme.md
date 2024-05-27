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

## Add new models and generate migrations

As an example, let's start by creating a model definition for Hint table. We create a class file `Hint.cs` in `Models` directory and add the following

### Create the Hint.cs file and Hint class
We define a namespace of our existing project, which is `firm-app` (the name of our project). This is a good practice. 
then we create the class called `Hint` and add all the properties from our ERD. The primary key is HintId and we use Guid as datatype. Then we see from our ERD, that some fields 
have different text lengths. Also, the datatype we want is `varchar` for text fields. This is why, we use `[Unicode(false)]` to indicate we do not want `nvarchar` (which is the default datatype used by entity framework to allow storing unicode strings). The `[Maxlength(25)]` will indicate the maximum character length. The question mark after the datatype indicates that we allow `null` or empty values in that column.


```cs

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Hint
    {
        [Key]
        public Guid HintId { get; set; }

        [Unicode(false)]
        [MaxLength(25)]
        public string? Topic { get; set; }

        [Unicode(false)]
        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool Anonymous { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}

```

### Allow the FirmDbContext to retrieve all values form Hint in the code

Now we can create a `DbSet<Hint>` property in `FirmDbContext` to allow our code to fetch all values from `Hint` table. 

### Create a new migration based on our changes
Now we should create a new migration for our newly created `Hint` model. We call our migrations `NewHints`.

```bash
dotnet ef migrations add NewHints
```

This will create all code related files to generate a new table by the name `Hint`. 


### finally apply the migration to see the changes in the database
Now we can apply the migration to our database

```bash
dotnet ef database update
```

This command will apply the latest migrations from our code which haven't been applied in the database. So in our example, it will simply create a new table by the name of `Hints`.


### Add all the models based on ERD 
Add all models and their relations. 

### Define all the models in FirmDBContext
This step will help us generate migrations. Once we add all the new tables as `DbSet` methods, then the new migration will pick these and create new tables in the script. 

### Create a new migration
Once we have added all the models and defined methods in `FirmDbContext`; we can generate a final migration to create all the tables in our db. 

```bash
dotnet ef migrations add AllFirmModels
```

This will generate a new migration containing all the new tables and relationships. 

### Apply the migration
We can test these migration by applying it to our database and see if all the tables are created successfully. We can also check the relationships in SQL Management Studio by generating an ERD automatically. 
