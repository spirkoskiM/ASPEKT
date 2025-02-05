# WebAPI

## Overview
This API provides functionality for managing countries, their associated companies, and contacts. It supports basic CRUD operations, filtering, logging, and error handling. It is built using C#, .NET 8, and Entity Framework Core.

---

## Features
- **CRUD Operations** for `Country`, `Company`, and `Contact`.
- **Filtering**: Search and filter by specific fields.
- **Swagger Documentation**: Interactive Swagger UI for API testing.
- **Error Handling**: Standardized error responses.
- **Logging**: Built-in logging system.
- **Unit Tests**: Coverage for key functionalities.

---

## API Endpoints

### **Country Endpoints**

#### **GET /api/Country**
Retrieve all countries from the database.

**Response Example**:
```json
[
  {
    "countryId": 1,
    "countryName": "Macedonia",
    "contacts": []
  },
  {
    "countryId": 2,
    "countryName": "Serbia",
    "contacts": []
  }
]
```

---

#### **POST /api/Country**
Create a new country.

**Request Body**:
```json
{
  "countryName": "Macedonia",
  "contacts": []
}
```

**Response Example**:
```json
{
  "countryId": 3,
  "countryName": "Macedonia",
  "contacts": []
}
```

---

#### **PUT /api/Country/{id}**
Update an existing country.

**Request Body**:
```json
{
  "countryName": "Updated Country Name",
  "contacts": []
}
```

**Response Example**:
```json
{
  "countryId": 1,
  "countryName": "Updated Country Name",
  "contacts": []
}
```

---

#### **DELETE /api/Country/{id}**
Delete a country by its ID.

**Response Examples**:
- `200 OK`: Country deleted successfully.
- `404 Not Found`: Country with the specified ID not found.

---

### **Swagger Documentation**
The API includes Swagger UI for testing and exploring available endpoints. Access it at:
```
http://localhost:{port}/swagger
```

---

## Project Structure

```
WebAPI/
├── Controllers/
│   └── CountryController.cs
│   └── CompanyController.cs
│   └── ContactController.cs
├── Data/
│   └── AppDbContext.cs
├── Models/
│   ├── Country.cs
│   ├── Company.cs
│   └── Contact.cs
├── Service/
│   ├── CompanyService.cs
│   ├── ContactService.cs
│   └── CountryService.cs
│   ├── ICompanyService.cs
│   ├── IContactService.cs
│   └── ICountryService.cs
├── Program.cs
└── appsettings.json
```

---

## How to Run the Application

### Prerequisites
- Install [.NET 8 SDK](https://dotnet.microsoft.com/).
- Set up MS SQL Server.

### Steps

1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd WebAPI
   ```

2. **Restore Dependencies**:
   ```bash
   dotnet restore
   ```

3. **Set Up Database**:
   - Update the connection string in `appsettings.json` to match your database configuration.
   - Apply migrations to create the database schema:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application**:
   ```bash
   dotnet run
   ```

5. Open your browser and navigate to `http://localhost:{port}/swagger` to test the API.

---

## Technologies Used
- **C#**
- **.NET 8**
- **Entity Framework Core**
- **MS SQL Server**
- **Swagger UI**

---

## Error Responses
Errors are returned in the following format:

```json
{
  "statusCode": 404,
  "message": "Resource not found.",
  "details": "Additional information about the error."
}
```

---

## Logging
All API operations are logged to the console by default. Logging can be extended to external storage solutions.

---

## Unit Tests
Unit tests ensure the reliability of the API. To run tests:
```bash
cd Tests

dotnet test
```

---

### Notes
- Ensure the database connection is properly configured in `appsettings.json`.
- The project uses a simplified architecture for easier implementation and evaluation.

---

### Author
Prepared by: Marko Spirkoski

