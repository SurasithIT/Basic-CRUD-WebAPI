## Install command integrate entityframework
`dotnet tool install --global dotnet-ef`

## School Database
`dotnet ef dbcontext scaffold "DataSource=SchoolDb.db" Microsoft.EntityFrameworkCore.Sqlite`
`dotnet ef migrations add SchoolDb --context SchoolDbContext`