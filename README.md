# Contact Management System REST API


**Authentication:**
- **POST /api/auth/register**: Register a new user.
- **POST /api/auth/login**: Log in and get an access token.

**Users:**
- **GET /api/users/me**: Get the current user's information.
- **PUT /api/users/me**: Update the current user's information.

**Contacts:**
- **GET /api/contacts**: Get a list of all contacts.
- **GET /api/contacts/{contactId}**: Get details of a specific contact.
- **POST /api/contacts**: Create a new contact.
- **PUT /api/contacts/{contactId}**: Update details of a specific contact.
- **DELETE /api/contacts/{contactId}**: Delete a specific contact.

**Addresses:**
- **GET /api/contacts/{contactId}/addresses**: Get all addresses for a specific contact.
- **GET /api/contacts/{contactId}/addresses/{addressId}**: Get details of a specific address for a contact.
- **POST /api/contacts/{contactId}/addresses**: Add a new address to a contact.
- **PUT /api/contacts/{contactId}/addresses/{addressId}**: Update details of a specific address for a contact.
- **DELETE /api/contacts/{contactId}/addresses/{addressId}**: Delete a specific address for a contact.

**Contact Numbers:**
- **GET /api/contacts/{contactId}/numbers**: Get all contact numbers for a specific contact.
- **GET /api/contacts/{contactId}/numbers/{numberId}**: Get details of a specific contact number for a contact.
- **POST /api/contacts/{contactId}/numbers**: Add a new contact number to a contact.
- **PUT /api/contacts/{contactId}/numbers/{numberId}**: Update details of a specific contact number for a contact.
- **DELETE /api/contacts/{contactId}/numbers/{numberId}**: Delete a specific contact number for a contact.

<!-- 
    // https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection
    dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
    
    // https://www.nuget.org/packages/BCrypt.Net-Next/
    dotnet add package BCrypt.Net-Next --version 4.0.3

    // https://www.nuget.org/packages/Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore --version 7.0.9

    // https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.9

    // https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.9

    // https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt
    dotnet add package System.IdentityModel.Tokens.Jwt --version 6.32.1
    
    // https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens
    dotnet add package Microsoft.IdentityModel.Tokens --version 6.32.1

    // https://www.nuget.org/packages/Swashbuckle.AspNetCore.Filters
    dotnet add package Swashbuckle.AspNetCore.Filters --version 7.0.8

    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer;

    dotnet add package Microsoft.AspNetCore.Mvc.Versioning

    dotnet add package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer

-->