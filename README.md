# REST API with EF controller actions, .NET8
### Visual Studio 2022
- project template: `ASP.NET Core Web API`
- [x] place solutioon and project in the same directory
- framework: .`NET 8.0`
- [x] configurate for https
- [x] enable Open API Support (swagger)
- [x] use controllers (MVC)

### SQL Server Object Explorer (View > )
- localdb\MSSQLLocalDb > `new Querry`
- make the database

### Package Manager Console (Tools > NuGet package Manager > )
```console
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```
```console
Install-Package Microsoft.EntityFrameworkCore.Design
```
```console
Install-Package Microsoft.EntityFrameworkCore.Tools
```
---
```console
Scaffold-DbContext "XxxConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context XxxDbContext -DataAnnotations
```

### appsettings.json:
```json
"ConnectionStrings": {
    "DefaultConnection": "XxxConnectionString"
  },
```
### program.cs
```csharp
var connectionString = builder.Configuration
	.GetConnectionString("DefaultConnection");
builder.Services
	.AddDbContext<_MyDbContext_>
	(opt => opt.UseSqlServer(connectionString));
```
	
### [Controllers] > Add > new scaffolded item...
### API Controller with actions using EF
model class::: _MyModel_
dbcontext class::: _MyDbContext_
controller name::: _MyModel_s (default)

--- allow CORS (to program.cs) ---

builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));

// add this BEFORE app.UseHttpsRedirection();
app.UseCors();