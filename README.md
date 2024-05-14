# E-commerce Website ASP.Net Core Web API

## Description

This project is an e-commerce website built using ASP.Net Core Web API, Entity Framework Core, Identity Framework, and n-tier architecture. It implements DTOs, repositories, services, and controllers to create a well-structured and maintainable application.

## Technologies

- **ASP.Net Core Web API:** The framework for building the web API.
- **Entity Framework Core:** An object-relational mapper (ORM) for interacting with the database.
- **Identity Framework:** A framework for implementing user authentication and authorization.
- **N-tier architecture:** A software design pattern that separates the application into multiple layers.

## Layers

- **Data Access Layer (DAL):** This layer interacts with the database using Entity Framework Core. It defines repositories that encapsulate database operations.
- **Business Logic Layer (BLL):** This layer contains the core business logic of the application. It defines services that use repositories to perform business operations.
- **Presentation Layer (PL):** This layer defines the API controllers that handle HTTP requests and responses. It uses services from the BLL to process requests.

## DTO (Data Transfer Objects)

DTOs are used to transfer data between layers. They are plain C# classes that represent the data being transferred.

## Repositories

Repositories provide an abstraction for accessing data from the database. They define methods for CRUD (Create, Read, Update, Delete) operations.

## Services

Services contain the business logic of the application. They use repositories to access data and perform business operations.

## Controllers

Controllers handle HTTP requests and responses. They use services from the BLL to process requests and return responses.
