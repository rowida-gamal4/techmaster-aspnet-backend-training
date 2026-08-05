## JWT Authentication Flow

This API uses JWT Bearer Authentication to protect secured endpoints.

## Registration

The user registers through:

'POST /api/auth/register'

The registration flow is:

- The request is validated.
- Duplicate emails are rejected.
- The role is validated.
- The password is hashed using BCrypt.
- A Student or Instructor is created based on the selected role.
- An 'ApplicationUser' is created and linked to the Student or Instructor.
- The password is never stored as plain text.
- A safe 'RegisterResponse' is returned without the password or password hash.

## Login

The user logs in through:

'POST /api/auth/login'

The login flow is:

1. Finds the user by email.
2. Checks that the account is active.
3. Verifies the password against the stored BCrypt hash.
4. Generates a JWT token.
5. Updates 'LastLoginAt'.
6. Returns an 'AuthResponse' containing the access token and safe user information.

The JWT contains:

- User ID
- Email
- User role
- User name
- Expiration time

Sensitive information is never included in the JWT, including passwords, password hashes, database connection strings, API keys, or secrets.


##  Get Current User

'GET /api/auth/me' 

uses the User ID from the JWT claims to identify the current user and retrieve the latest user information from the database.

The response contains safe user information only and does not expose the password hash.

##  Change Password

'POST /api/auth/change-password' requires authentication.

The Change Password flow is:

- Gets the current user from the JWT.
- Verifies the current password.
- Validates the new password.
- Hashes the new password using BCrypt.
- Saves the new password hash.
- Updates 'UpdatedAt'.

## JWT Token Generation

After successful authentication, the TokenService creates a signed JWT.

The token contains identity and authorization information needed by the API.

Current claims include:
- NameIdentifier : Identifies the user's ID
- Email : Identifies the user's email
- Name : Stores the user's full name
- Role : Used for role-based authorization
- exp : Token expiration time

The token is signed using the configured JWT secret key and uses the configured: Issuer - Audience - Expiration time -Signing key

The API validates these values when receiving a JWT.

## Using the Token

Protected endpoints require the token in the Authorization header:

'Authorization: Bearer <token>'

Endpoints protected with '[Authorize]' reject requests without a valid token.

Role-based endpoints can use '[Authorize(Roles = "Admin")]' or another required role.

## JWT Security

The API validates the JWT signature, issuer, audience, and expiration time.

A missing, invalid, or expired token is rejected.

An authenticated user without the required role receives 403 Forbidden.

JWT tokens never contain passwords, password hashes, database credentials, API keys, or other secrets.