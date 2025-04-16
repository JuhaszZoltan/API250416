# REST API with EF controller actions, .NET8
### ==Visual Studio 2022==
- project template: `ASP.NET Core Web API`
- [x] place solutioon and project in the same directory
- framework: .`NET 8.0`
- [x] configurate for https
- [x] enable Open API Support (swagger)
- [x] use controllers (MVC)

==SQL Server Object Explorer== (View > )
- localdb\MSSQLLocalDb -> `new Querry`
> make the database

==Package Manager Console== (Tools > NuGet package Manager > )
```shell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```
```shell
Install-Package Microsoft.EntityFrameworkCore.Design
```
```shell
Install-Package Microsoft.EntityFrameworkCore.Tools
```


```shell
Scaffold-DbContext "$MyConnectionString$" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context $MyDbContext$ -DataAnnotations
```

--- to appsettings.json: ---
"ConnectionStrings": {
    "DefaultConnection": "_MyConnectionString_"
  },

--- to program.cs ---
```cs
var connectionString = builder.Configuration
	.GetConnectionString("DefaultConnection");
builder.Services
	.AddDbContext<_MyDbContext_>
	(opt => opt.UseSqlServer(connectionString));
```
	
--- Controllers forlder -> Add -> new scaffolded item... ---

-> API Controller with actions using EF ->
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