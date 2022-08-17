# dotnet-bakery

This is the starting point for teaching an intro to .NET Core WebAPI project. The models and controllers are stubbed out but empty.

![](https://cdn-blog.adafruit.com/uploads/2010/11/gingerbread03.jpg)

# Setup from scratch

`dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`
`dotnet add package Microsoft.EntityFrameworkCore.Design`

# tool for connecting database

`dotnet tool install --global dotnet-ef`

# setup with database

string DATABASE_URL = Environment.GetEnvironmentVariable("DATABASE_URL_STR");
string connectionString = (DATABASE_URL == null ? Configuration.GetConnectionString("DefaultConnection") : DATABASE_URL);
Console.WriteLine($"Using connection string: {connectionString}");

            "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=bakery;"

}

# baker model and database => model first

[1] Models/Baker.cs => define columns
[2] Active Baker.cs model => ApplicationContext.cs
public DbSet<Baker> Bakers {get; set;}
[3] Migration
`dotnet ef migrations add CreateBakerTable`
`dotnet ef database update`

# baker controller

[1] BakersController.cs => [HttpGet]
[2] Migration
`dotnet ef migrations add CreateBreadTable`
`dotnet ef database update`
[3] `dotnet watch run`

# bread model class

[1] Bread.cs => Bread(id, name, description, count, bakedById)
[2] BreadType
public enum BreadType
[JsonConverter(typeof(JsonStringEnumConverter))]

# bread controller => PUT, DEL

[1] PUT
[2] DEL
