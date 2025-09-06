# ToDoList – Clean Architecture (.NET)

A web-based To-Do List application developed with **.NET Core** and **Clean Architecture** principles.  
It allows users to **add, delete, and mark tasks as completed** while providing **automatic alerts** when deadlines are approaching (e.g., “3 days left”, “1 day left”).

## ✨ Features
- Add new tasks with title, description, and due date
- Mark tasks as **Completed** or revert to **Active**
- Delete tasks permanently
- Automatic deadline alerts:
  - “3 days left” warning
  - “1 day left” warning
- Built on **Clean Architecture** with layered structure

## 🧱 Architecture
- **Presentation**: Web API controllers / endpoints  
- **Application**: CQRS (Commands & Queries), validation, business logic  
- **Domain**: Core entities (`TodoItem`), rules, events  
- **Infrastructure**: EF Core, repositories, database access  

## 📦 Technologies
- .NET 8 / ASP.NET Core Web API  
- Entity Framework Core (SQL Server)  
- CQRS with MediatR  
- FluentValidation  
- AutoMapper (optional)  
