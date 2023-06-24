 # ASP.NET Core WebApi - Clean Architecture
<br/>

### An Implementation of Clean Architecture with ASP.NET WebApi for an E-Commerce Website.

1. Clone this Repository and Extract it to a Folder.
3. Change the Connection Strings for the Application and Identity in the WebApi/appsettings.json - (WebApi Project)
4. PMC project: InfrastructureShared
5. Startup project: WebApi
6. Run the following commands on Powershell in the WebApi Projecct's Directory
- dotnet restore
- dotnet ef database update -c ApplicationDbContext --project WebApi
- dotnet ef database update -c IdentityDbContext --project WebApi

Alternatively, you can switch the UseInMemoryDatabase flag in appsettings.json and use the in-memory database.

### Default Roles & Credentials
As soon you build and run your application, default users and roles get added to the database.

Default Roles are as follows.
- SuperAdmin
- Admin
- Moderator
- Basic

Here are the credentials for the default users.
- Email - superadmin@gmail.com  / Password - 123Pa$$word!
- Email - basic@gmail.com  / Password - 123Pa$$word!

You can use these default credentials to generate valid JWTokens at the ../api/account/authenticate endpoint.

### Front-End
The front-end for this app may be found in [this](https://github.com/piotrokrutniak/hardware-onion-store) repository.

### Google Drive Integration
To utilize the Google Drive API Integration you will need to obtain a JSON file for OAuth2 authorization.
More details on this here: https://developers.google.com/identity/protocols/oauth2

Simply go through the setup, insert the JSON file to the root folder of WebAPI project and rename to credentials.json

![image](https://github.com/piotrokrutniak/HardwareOnion/assets/91792866/4f067666-200b-4a38-a2ae-71ef3044caf0)
