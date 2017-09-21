# connect_api
Api .net core application for rest calls

# Tech-Stacks
**Language**
1. C#

** Compiler **
1. [.net core 1.1](https://www.microsoft.com/net/download/core)
.NET Core is a blazing fast, lightweight and modular platform for creating web applications and services that run on Windows, Linux and Mac

**IDE** : 
1. [Visual Studio 2017](https://www.visualstudio.com/downloads/)

**DataBase**:
1. [SqlLite](https://www.sqlite.org/)
2. Model based database

**Packages**:
1. Pagination : Internal package 
## Usage

This package is used for the WebApi Get calls which requires Pagination. The Api call should be invoked by passing the `page` and `per_page` parameters like `http://localhost:5000/companies?page=1&perpage=2`. 

### Implementation

####Accept

Accept the parameter `PaginationParams` from your Controller. The input parameters `page` and `per_page` get mapped to the `PaginationParams` object through `[FromUri]` attribute.

```csharp
[HttpGet]
public IActionResult Get([FromUri] PaginationParams paginationParams)
```

####Invoke

Within your data (repository) layer invoke the `GetList` for your corresponding queryable object where `List` is an `IQueryable` extension. The result is of type `List<T>` where T is the corresponding database entity. In the below example it is `Company` and `query` is an `IQueryable` object.

```csharp
public override List<Company> GetList(PaginationParams paginationParams, SortingInfo sortingInfo)
{
    sortingInfo.Add(nameof(Company.CompanyName), Sorting.Sorting.Asc);

    var query = _context.Companies.GetList(paginationParams).IncludeOrderBy(sortingInfo).Include(a => a.Address)
        .AsNoTracking();
    return query.ToList();
}
```
2. Sorting : Internal package
## Usage

This package is used for the WebApi Get calls which requires sorting. The Api call should be invoked by passing the `field` and `asc/dsc` parameters like `http://localhost:5000/companies?sort=field_asc;field_dsc`. 

### Implementation

####Accept

Accept the parameter `SortingInfo` from your Controller. The input parameters `sortingInfo` get mapped to the `SortingInfo` object through `[FromUri]` attribute.

```csharp
[HttpGet]
public IActionResult Get([FromUri] SortingInfo sortingInfo)
```

####Invoke

Within your data (repository) layer invoke the `IncludeOrderBy` for your corresponding queryable object where `List` is an `IQueryable` extension. The result is of type `List<T>` where T is the corresponding database entity. In the below example it is `Comapny` and `query` is an `IOrderedQueryable<T>` object.

```csharp
public override List<Company> GetList(PaginationParams paginationParams, SortingInfo sortingInfo)
{
    sortingInfo.Add(nameof(Company.CompanyName), Sorting.Sorting.Asc);

    var query = _context.Companies.GetList(paginationParams).IncludeOrderBy(sortingInfo).Include(a => a.Address)
        .AsNoTracking();
    return query.ToList();
}
```

## Documentation
You could navigate to [Swagger UI] (https://localhost:port/swagger) endpoint for an interactive documentation of the API.

The Swagger representation of the API is defined using a JSON file. You could navigate to [Swagger JSON File Generator](https://localhost:port/docs/swagger.json) to generate the JSON file.
