# Cosmalyze.Api

Cosmalyze.Api is a .NET 8 Web API for managing products, categories, and brands. This API provides endpoints to perform CRUD operations and search functionality for products.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Endpoints](#endpoints)

## Getting Started

These instructions will help you set up and run the project on your local machine for development and testing purposes.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- SQLite

## Installation

1. Clone the repository:
   git clone https://github.com/gurkankizik/Cosmalyze-Api.git cd Cosmalyze.Api

2. Restore the dependencies:
   dotnet restore

3. Update the database:
   dotnet ef database update

4. Run the application:
   dotnet run

## Usage

The API provides endpoints to manage products, categories, and brands. You can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to interact with the API.

### Swagger UI

You can also use the Swagger UI to explore and test the API endpoints. Once the application is running, open your web browser and navigate to:
https://localhost:7249/swagger/index.html
This will open the Swagger UI where you can see all available endpoints and interact with them directly from the browser.

## Endpoints

### Products

- **GET /api/products**: Get all products.
- **GET /api/products/{id}**: Get a product by ID.
- **POST /api/products**: Create a new product.
- **PUT /api/products/{id}**: Update an existing product.
- **DELETE /api/products/{id}**: Delete a product by ID.
- **GET /api/products/Search?name={searchTerm}**: Get a product by name.

### Brands

- **GET /api/brands**: Get all brands.
- **GET /api/brands/{id}**: Get a brand by ID.
- **POST /api/brands**: Create a new brand.
- **PUT /api/brands/{id}**: Update an existing brand.
- **DELETE /api/brands/{id}**: Delete a brand by ID.
- **GET /api/brands/Search?name={searchTerm}**: Get a brand by name.

### Search

- **GET /api/find?name={searchTerm}**: Search for products and brands by name. This endpoint returns a combined list of products and brands that match the search term.
