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


```console
Scaffold-DbContext "_MyConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context _MyDbContext -DataAnnotations
```

### appsettings.json:
```json
"ConnectionStrings": {
    "DefaultConnection": "_MyConnectionString"
  },
```
### program.cs
> add ef db service
```csharp
builder.Services.AddDbContext<_MyDbContext>(opt => 
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
```
> add CORS service
```csharp
builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()));
```
> use CORSE
```csharp
// must be BEFORE app.UseHttpsRedirection();
app.UseCors();
```

### [Controllers] > Add > new scaffolded item... > `API Controller with actions using EF`

|model class:| _MyModel|
|dbcontext class:| _MyDbContext|
|controller name:| _MyModels (default)|