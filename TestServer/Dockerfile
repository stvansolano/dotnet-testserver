FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

# Modified stage
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY [".", "."]
WORKDIR /TestServer
RUN dotnet restore "Tests.csproj"
RUN dotnet build "Tests.csproj" -c Release -o /app/build
RUN [ "dotnet", "test" ]

### How to run tests (from root folder):
### docker build --pull --rm -f "src/TestServer/Dockerfile" -t testserver:latest .
###

# Commented section
# 'build' stage
#RUN dotnet build "Tests.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Tests.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Tests.dll"]