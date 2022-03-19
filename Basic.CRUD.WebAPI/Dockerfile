FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Basic.CRUD.WebAPI/Basic.CRUD.WebAPI.csproj", "Basic.CRUD.WebAPI/"]
RUN dotnet restore "Basic.CRUD.WebAPI/Basic.CRUD.WebAPI.csproj"
COPY . .
WORKDIR "/src/Basic.CRUD.WebAPI"
RUN dotnet build "Basic.CRUD.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basic.CRUD.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basic.CRUD.WebAPI.dll"]
