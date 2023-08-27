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
- **PATCH /api/contact/{contactId}**: Update specific detail of a specific contact.
- **DELETE /api/contact/{contactId}**: Delete a specific contact.
