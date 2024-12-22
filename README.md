# Todo List API

## Overview

This project is a simple Todo List Web API implemented using .NET Core, designed to demonstrate best practices in API development while adhering to the Clean Architecture principles. The API supports creating, updating, and retrieving Todo items and is implemented with modern tools and patterns for maintainability and scalability.

---

## Features

1. _Core Features:_
   - Create a new Todo item.
   - Mark a Todo item as completed.
   - Retrieve all Todo items.
   - Retrieve completed Todo items.
   - Retrieve pending (not completed) Todo items.
2. _Additional Features:_
   - _CQRS Pattern:_ Clear separation of command and query responsibilities.
   - _FluentValidation:_ Used for request validation.
   - _Serilog:_ Integrated for structured logging.
   - _EF Core 8:_ Utilized with an in-memory database for simplicity.
   - _In-Memory Caching:_ Caching for improved performance.
   - _API Versioning:_ To support future iterations and backward compatibility.
   - _Unit Tests:_ Comprehensive tests using Moq.
   - _Clean Architecture:_ Organized into Domain, Application, Infrastructure, and Presentation layers.
   - _Vertical Slicing:_ Features grouped for easy maintainability.
   - _Domain-Driven Design (DDD):_ Emphasis on domain entities and rich domain modeling.
   - _Generic Repository and Unit of Work Patterns:_ Simplifies data access.
   - _Specification Pattern:_ For flexible and reusable query filters.
   - _Result Pattern:_ Unified approach to handling results and errors.
   - _Localization:_ Error messages support multiple languages.
   - Swagger: API documentation for easier interaction and testing.

---

## API Endpoints

### Version: v1.0

| Endpoint                       | HTTP Method | Description                    |
| ------------------------------ | ----------- | ------------------------------ |
| /api/v1/todo/AddToDoitem       | POST        | Create a new Todo item.        |
| /api/v1/todo/getallToDoItems   | GET         | Retrieve all Todo items.       |
| /api/v1/todo/CompleteToDo/{id} | PUT         | Mark a Todo item as completed. |

---

## Tech Stack

- _.NET 8_: Latest framework features.
- _Entity Framework Core 8_: Simplified data access.
- _FluentValidation_: Validation for request models.
- _Serilog_: Enhanced logging.
- _Swagger_: Auto-generated API documentation.
- _Moq_: Unit testing with mocked dependencies.

---

## Architecture

- _Domain Layer:_ entities , DDD .
- _Application Layer:_ Handles CQRS, validation, and DTO mappings.
- _Infrastructure Layer:_ Implements Migrations , DbContext .
- _Api Layer:_ API controllers.

---

## Note

- Change the connection string at appsettings.json and run the project it will automatically create the database apply the migrations and seed dummy data for test

## Author

Mostafa Amer
