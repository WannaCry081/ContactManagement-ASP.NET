# Contact Management System REST API


**Authentication:**
- **POST /api/auth/signup**: Register a new user.
- **POST /api/auth/signin**: Log in and get an access token.

**Users:**
- **GET /api/users/me**: Get the current user's information.
- **PUT /api/users/me**: Update the current user's information.

**Contacts:**
- **GET /api/contact**: Get a list of all contacts.
- **GET /api/contact/{contactId}**: Get details of a specific contact.
- **POST /api/contact**: Create a new contact.
- **PUT /api/contact/{contactId}**: Update details of a specific contact.
- **DELETE /api/contact/{contactId}**: Delete a specific contact.

**Addresses:**
- **GET /api/contact/{contactId}/address**: Get all addresses for a specific contact.
- **GET /api/contact/{contactId}/address/{addressId}**: Get details of a specific address for a contact.
- **POST /api/contact/{contactId}/address**: Add a new address to a contact.
- **PUT /api/contact/{contactId}/address/{addressId}**: Update details of a specific address for a contact.
- **DELETE /api/contact/{contactId}/address/{addressId}**: Delete a specific address for a contact.

**Contact Numbers:**
- **GET /api/contact/{contactId}/number**: Get all contact numbers for a specific contact.
- **GET /api/contact/{contactId}/number/{numberId}**: Get details of a specific contact number for a contact.
- **POST /api/contact/{contactId}/number**: Add a new contact number to a contact.
- **PUT /api/contact/{contactId}/number/{numberId}**: Update details of a specific contact number for a contact.
- **DELETE /api/contact/{contactId}/number/{numberId}**: Delete a specific contact number for a contact.

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

<!-- 

    Backend
    - Add audit log

    UserLog
=============================
- id : int : pk
- userId : int
- email : string
- eventDetails : string
	- Message 
		User '{FirstName} {LastName}' with the Username '{UserName}' signed in successfully	
		User '{FirstName} {LastName}' with the Username '{UserName}' registered successfully
- eventType : CRUD
	- Sign in
	- Sign up
- eventTime : Datetime


ContactLog
=============================
- id : int : pk
- contactId : int
- userId : int
- eventDetails : string
	- Message
		User 'Lirae Data' successfully created a contact.
		User 'Lirae Data' updated the contact details.
		User 'Lirae Data' deleted a contact.
		User 'Lirae Data' viewed the contact details.
				
- data : Contact
- eventTime : Date
- eventType : CRUD 
	- Created
	- Retrieved
	- Updated
	- Deleted

    - Change to nullables

    Frontend
    - Connect frontend and backend
    - authorized pages
    - Design frontend
-->