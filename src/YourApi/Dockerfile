FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY ["YourApi", "./YourApi"]
WORKDIR "/YourApi"
RUN dotnet restore "./YourApi.csproj"
RUN dotnet build "YourApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YourApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YourApi.dll"]
EXPOSE 80

#ENV ConnectionStrings__DefaultDatabase $ConnectionStrings__DefaultDatabase

# docker build -f Dockerfile -t your-api:latest .
# docker run -d  -p 443:443/tcp -p 80:80/tcp your-api:latest -e ConnectionStrings__DefaultDatabase="Data Source=db-sql-server,1433;initial catalog=TestDatabase;persist security info=True;user id=sa;password=Password.123;MultipleActiveResultSets=True;App=EntityFrameworkApp=EntityFramework"