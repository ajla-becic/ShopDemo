# NewRepo – Shopping Basket & User Management API

This ASP.NET Core Web API provides basic functionality for managing users, shopping baskets, and product listings.

## Features

- **User Authentication**  
  - JWT-based login and registration

- **Basket Management**  
  - Add and remove products from a user's basket (requires authentication)

- **Favorites**  
  - Mark products as favorites

- **Product Listing**  
  - Retrieve a list of products (fetched from an external source and not stored in the database)

- **Sorting and Pagination**  
  - Filter and paginate the product listing

- **Caching**  
  - In-memory caching of product data for performance

- **Exception Handling**  
  - Global exception handling middleware for consistent error responses

## Getting Started

### 1. Create the Database

Before running the application, ensure SQL Server is running locally. Create a new database named **AbySalto**

### 2. Apply Entity Framework Migrations

Open **Package Manager Console** in Visual Studio and run **Update-Database**. This will generate the required tables and schema in the `AbySalto` database.

### 3. Run the Application

Start the project. Once running, open the following URL in your browser **https://localhost:7221/index.html** 
Swagger UI will be available for exploring and testing the API endpoints.

## Authentication

- The `BasketController` requires JWT Bearer authentication.
- `ProductController` allows anonymous access.

### How to Authenticate

1. Use the `/register` endpoint to create a new user.
2. Use the `/login` endpoint to authenticate and retrieve a JWT token.
3. In Swagger, click the **Authorize** button and paste the token to access protected endpoints like basket management.
