# Contact Management REST API

This is a comprehensive REST API for a Contact Management System built using ASP.NET Core. It provides endpoints for managing users and contacts.

## Overview

The Contact Management System REST API is designed to facilitate the management of user information and contacts. It includes authentication endpoints for user registration and login, as well as user and contact management endpoints.

### Authentication

- **POST /api/auth/signup**: Register a new user.
- **POST /api/auth/signin**: Log in and get an access token.

### Users

- **GET /api/users/me**: Get the current user's information.
- **PUT /api/users/me**: Update the current user's information.

### Contacts

- **GET /api/contact**: Get a list of all contacts.
- **GET /api/contact/{contactId}**: Get details of a specific contact.
- **POST /api/contact**: Create a new contact.
- **PUT /api/contact/{contactId}**: Update details of a specific contact.
- **PATCH /api/contact/{contactId}**: Update specific detail of a specific contact.
- **DELETE /api/contact/{contactId}**: Delete a specific contact.

## Installation (ASP.NET)

To run this ASP.NET Core application, follow these steps:

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/TheDayDreamer01/ContactManagement-ASP.NET.git
   ```

2. **Navigate to the Project Directory:**

   ```bash
   cd contactmanagement-asp.net
   ```

3. **Restore Dependencies:**

   ```bash
   dotnet restore
   ```

4. **Run the Application:**

   ```bash
   dotnet run
   ```

5. The API should now be running at `http://localhost:5000`. You can access the Swagger documentation at `http://localhost:5000/swagger` for detailed API documentation and testing.

## Use of Docker (Dockerfile)

This API can also be containerized using Docker. A `Dockerfile` is included in the repository.

To build and run the API in a Docker container, follow these steps:

1. **Build the Docker Image:**

   ```bash
   docker build -t contactmanagementsystem-backend .
   ```

2. **Run the Docker Container:**

   ```bash
   docker run -d -p 8000:80 --name contact-management-container contactmanagementsystem-backend
   ```

3. The API should now be running in a Docker container, and you can access it at `http://localhost:8000`.

## License

This Contact Management System REST API is open-source software licensed under the [MIT License](LICENSE). Feel free to use, modify, and distribute it as needed.

