# REST API with EF controller actions, .NET8
### Visual Studio 2022
- project template: `ASP.NET Core Web API`
- [x] place solutioon and project in the same directory
- framework: .`NET 8.0`
- [x] configurate for https
- [x] enable Open API Support (swagger)
- [x] use controllers (MVC)

### `SQL Server Object Explorer` (View > )
> make the database from the .sql dump[^2]
- localdb\MSSQLLocalDb > `new Querry`

### `Package Manager Console`[^1] (Tools > NuGet package Manager > )
```console
Install-Package Microsoft.EntityFrameworkCore.SqlServer -version:8.0.22
```
```console
Install-Package Microsoft.EntityFrameworkCore.Design -version:8.0.22
```
```console
Install-Package Microsoft.EntityFrameworkCore.Tools -version:8.0.22
```
```console
Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -version:8.0.22
```
```console
Update-Package Swashbuckle.AspNetCore -version:8.1.4
```


```console
Scaffold-DbContext "_MyConnectionString" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context _MyDbContext -DataAnnotations
```

### appsettings.json:[^1]
```json
"ConnectionStrings": {
    "DefaultConnection": "_MyConnectionString"
  },
```
### program.cs[^1]
> add ef db service
```csharp
builder.Services.AddDbContext<_MyDbContext>(opt => 
    opt.UseSqlServer(
        builder.Configuration
        .GetConnectionString("DefaultConnection")));
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

### [Controllers] > Add > new scaffolded item... > 
### `API Controller with actions using EF`[^1]

|    attribute    |       value        |
| :---            |               ---: |
|model class:     |           _MyModel |
|dbcontext class: |       _MyDbContext |
|controller name: |          _MyModels |

[^1]: replace the term `_My` with the name of the model (singular or plural depending on the context!).
[^2]: If necessary, convert thie source. In T-SQL `INT`s have no length and `AUTO_INCREMENT` is equivalent to `IDENTITY`. `CREATE DATATABASE` and `USE` must be driven separate sessions from `CREATE TABLE` and `INSERT INTO`.
