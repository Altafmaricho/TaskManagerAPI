TaskManagerAPI 

A simple ASP.NET Core Web API for managing tasks with **JWT Authentication** and **Role-Based Authorization**.

## Features

Login with JWT Token
Role-based access control (Admin, User)
CRUD operations on Tasks
In-Memory Database for testing
Swagger UI for interactive API testing

## Getting Started

### 1. Clone the Repository or download the project

bash
git clone https://github.com/your-username/TaskManagerAPI.git
cd TaskManagerAPI

2. ## Install Dependencies
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Swashbuckle.AspNetCore

3. ## dotnet run


4. ## Testing via Swagger
Navigate to https://localhost:<port>/swagger

Use /api/auth/login to get a token

{
  "username": "admin",
  "password": "admin"
}
--
Here you u get token in resonse body. copy that token and paste in Authorize.
## Click "Authorize" → Paste Bearer <your_token>

Test other endpoints.

