# DDD Clean architecture project template

## Instruction on running project

1. Download or clone this repository to your local machine and change your working directory to the repository directory.

```bash
$ git clone <repo-url>
$ cd <repo-directory>
```

2. Run the following command:

```bash
$ dotnet watch run --project ./Source/RestApi
```

![Banner](https://blob.jacobsdata.com/software-alchemy/entry8/clean-domain-driven-design-jacobs-510.png)

This is a project template that uses the Domain driven design principles. The project have the following structure:

## Domain

The Domain layer contains the core business components. This project contains Entities, Exceptions, ValuesObject, Aggregate roots and so on. The domain project doesn't have ( and should not have) any dependency to the rest of the application.

## Application

The Application layer contains the core business logic. This template uses the CQRS patter and Commands and Queries are defined separately. This projects has a dependency to the domain and only domain layer.

```xml
<ItemGroup>
    <ProjectReference Include="..\Domain\Domain.csproj" />
</ItemGroup>
```

### Packages

```xml
<ItemGroup>
    <PackageReference Include="AutoMapper" Version="11.0.1" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="11.0.0" />
    <PackageReference Include="MediatR" Version="10.0.1" />
    <PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="10.0.1" />
</ItemGroup>
```

## Infrastructure

This layer contains the external service logic. For example: database access and HttpClient logic should got here. This template uses the INMemory database for data persistently which can be easy swapped out. The Infrastructure layer depends on the Application and Domain layer.

```xml
<ItemGroup>
    <ProjectReference Include="..\Application\Application.csproj" />
    <ProjectReference Include="..\Domain\Domain.csproj" />
</ItemGroup>
```

### Packages

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.6" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="6.0.6" />
</ItemGroup>
```

## RestApi

This is the Rest Api layer. Depends on all the layer below, however it only depends on the infrastructure to only register services..

```xml
<ItemGroup>
    <ProjectReference Include="..\Application\Application.csproj" />
    <ProjectReference Include="..\Domain\Domain.csproj" />
    <ProjectReference Include="..\Infrastructure\Infrastructure.csproj" />
</ItemGroup>
```

Infrastructure services registrations in `Program.cs`

```c#
builder.Services.InstallInfrastructureServices();
```

Service registration in Infrastructure layer.

```C#
public static void InstallInfrastructureServices(this IServiceCollection services)
{
    services.AddDbContext<AppDBContext>(opt => opt.UseInMemoryDatabase("InMemGymDb"));
    services.AddScoped<IRepository<User>, Repository<User>>();
}
```

```xml
<ItemGroup>
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="11.0.0" />
    <PackageReference Include="MediatR" Version="10.0.1" />
    <PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="10.0.1" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.2.3" />
</ItemGroup>
```
