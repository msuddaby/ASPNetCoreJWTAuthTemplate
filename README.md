# ASP.NET Core Web API JWT Authentication Template
A stock ASP.NET Core Web API template that comes with JWT Authentication built in. There's also a few helpful API endpoints to get started.

## Why?
Because I was tired of remaking my authentication handlers and endpoints every time I started a new project. I also don't like the way Microsoft's Identity platform works by default, so I made a few configuration modifications.

## Basic rundown of features
- JWT bearer authentication
- JWT token signing
- Refresh token support
- Support for roles and claims
- Login, logout, and basic user management HTTP endpoints included
- Docker support

## What does it use?
Mostly stock Microsoft packages. Here's a list of things I've modified / used that don't come stock with a Web API project.

- Entity Framework Core
  - The project is set up to use the Npgsql (Postgres) driver by default.
- Microsoft.AspNetCore.Authentication
  - Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity
  - All default models (roles, users, role claims, etc.) have been overwritten
    - Changed User class to include the following:
      - The default login / identity marker was changed from their email to their username. 
      - Create date property
      - Refresh token
      - Refresh token expiry
      - List of roles
        - List of roles is configured to be automatically included in every query involving users.
    - UserRole class
      - Includes the proper relationship fields
    - Role class
      -  Property for list of users in role.

## Docker?
Yes. Here's a [sample compose file that includes Postgres.](https://github.com/msuddaby/ASPNetCoreJWTAuthTemplate/blob/master/docker-compose.yml)



*more documentation to be added soon...*
