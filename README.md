# E-commerce Website ASP.Net Core Web API with React Client-Server

## Description

This project is an e-commerce website built using ASP.Net Core Web API, Entity Framework Core, Identity Framework, and n-tier architecture. It implements DTOs, repositories, services, and controllers to create a well-structured and maintainable application. The client-server communication is facilitated using React.

## Technologies

- **ASP.Net Core Web API:** The framework for building the web API.
- **Entity Framework Core:** An object-relational mapper (ORM) for interacting with the database.
- **Identity Framework:** A framework for implementing user authentication and authorization.
- **N-tier architecture:** A software design pattern that separates the application into multiple layers.
- **React:** Used for the client-server communication.

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


## Database Diagram
![Screenshot 2024-04-30 002657](https://github.com/Mohamedelgazzar1312/E-commerce-Api-/assets/153744543/1083698a-ad33-429e-9377-46fd33bc1d65)

## End points 
![Screenshot 2024-04-29 222900](https://github.com/Mohamedelgazzar1312/E-commerce-Api-/assets/153744543/c540fd15-dfa2-40f9-b1b8-e89c63d2f6f9)

![Screenshot 2024-04-29 222848](https://github.com/Mohamedelgazzar1312/E-commerce-Api-/assets/153744543/235e9c16-e455-4151-9482-2fe455e67037)

## Simple client side
![Screenshot 2024-04-29 222905](https://github.com/Mohamedelgazzar1312/E-commerce-Api-/assets/153744543/5b3b087a-8bd7-4ebf-8574-a09b75e697fb)

![Screenshot 2024-04-29 222940](https://github.com/Mohamedelgazzar1312/E-commerce-Api-/assets/153744543/5374d552-677c-4852-bfee-a0c81bbb5a34)



