# Cosmalyze.Api

Cosmalyze.Api is a .NET 8 Web API for managing products, categories, and brands. This API provides endpoints to perform CRUD operations and search functionality for products.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Endpoints](#endpoints)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- A database (e.g., SQL Server, SQLite, etc.)

## Installation

1. Clone the repository:
   git clone https://github.com/yourusername/Cosmalyze.Api.git cd Cosmalyze.Api

2. Restore the dependencies:
   dotnet restore

3. Update the database:
   dotnet ef database update

4. Run the application:
   dotnet run

## Usage

The API provides endpoints to manage products, categories, and brands. You can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to interact with the API.

## Endpoints

### Products

- **Get all products**: `GET /api/products`
- **Get a product by ID**: `GET /api/products/{id}`
- **Search products by name and/or UPC**: `GET /api/products/search?name={name}&upc={upc}`
- **Create a new product**: `POST /api/products`
- **Update a product**: `PUT /api/products/{id}`
- **Delete a product**: `DELETE /api/products/{id}`

### Categories

- **Get all categories**: `GET /api/categories`
- **Get a category by ID**: `GET /api/categories/{id}`
- **Create a new category**: `POST /api/categories`
- **Update a category**: `PUT /api/categories/{id}`
- **Delete a category**: `DELETE /api/categories/{id}`

### Brands

- **Get all brands**: `GET /api/brands`
- **Get a brand by ID**: `GET /api/brands/{id}`
- **Create a new brand**: `POST /api/brands`
- **Update a brand**: `PUT /api/brands/{id}`
- **Delete a brand**: `DELETE /api/brands/{id}`

   
   
   