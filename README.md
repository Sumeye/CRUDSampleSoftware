# .NET Core Web API CRUD Project
 The CRUD sample software is a web-based application that allows users to create, read, update,and delete data in a database.There is a simple user interface(swagger can be used).
## Versioning

| GitHub | .NET Core Version |  |
| :--- | :---: | ---: |
| main | 6.0.1222.57109 |  |

# Project Structure
```bash
│── CrudSample.API
│   └── Controllers
│      └── CustomBaseController.cs 
│      └── UserController.cs
│   └── Filter
│      └── ValidateFilterAttribute.cs
│   └── Modules
│      └── RepoServiceModule.cs
│   └── Properties
│      └── launchSettings.json
│   └── Program.cs
│   └── appsettings.Development.json
│   └── appsettings.json        
├── CrudSample.Core
│   └── DTOs
│   └── Models
│   └── Repositories
│   └── Services
│   └── UnitOfWork
│   └── CrudSample.Core.csproj
├── CrudSample.Repository
│   └── Configuration
│   └── Migrations
│   └── Repositories
│   └── UnitOfWork
│   └── AppDbContext.cs
│   └──CrudSample.Repository.csproj
├── CrudSample.Service
│   └── Exceptions
│   └── Mapping
│   └── Services
│   └── Validations
│   └── CrudSample.Service.csproj
├── CrudSampleUnitTest.Test
│   └── CrudSampleUnitTest.Test.csproj
│   └── UserApiControllerTest.cs
├── README.md
├── CRUDSampleSoftware.sln
├── script.sql
```
### sql run instructions
---
use `CREATE DATABASE CrudSampleDb;` to create database

###### `Script.sql` is required for  the database. Run the `Script.sql` file.

Create,Update Delete,Get methods use with swagger for run
Xunit; It was used to test the workability of the methods.

