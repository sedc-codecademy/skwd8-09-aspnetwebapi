# Building an API solution
## Architecture
* Data Models - Models and structures for Database transfer usage only
  * DTO Models
    * User
    * Note
  * Entity Framework Context
  * Migrations
* Data Access Layer - Database communication layer
  * Repositories ( User, Note )
    * ADO.NET Repositories
    * Entity Framework Repositories
    * Dapper Repositories
* Service Layer - Business logic layer connecting the Data Access and API Presentation layer
  * Services
    * User Service
    * Note Service
  * Helpers
    * DiModule - Module that registers repositories from the DataAccess layer for Dependency Injection ( So they would not be registered directly in the API project )
    * AppSettings - A configuration file that mapps the configurations from appsettings.json to properties for easy and centralized access to configurations
  * Exceptions
    * User Exception
    * Note Exception
* Models Layer - Models and structures that will be exposed to the outside world ( For API Presentation layer )
  * API Models ( View models in MVC )
    * Login Model
    * Register Model
    * NoteModel
    * UserModel
* API Presentation Layer - Interface to the outside world ( Receiving and accepting requests )
  * Controllers
  * Configurations
    * appsettings.json
      * Configuration strings
    * startup.cs
      * Authorization configuration
      * Dependency Injection configuration
      * AppSettings register

![Architecture Image](../img/Architecture.jpg)
