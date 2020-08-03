# ASP.NET Test Server

[Twitter: @stvansolano](https://twitter.com/stvansolano)

## Do you like it? Give a Star! :star:

If you like or are using this project to learn or start your own solution, please give it a star. I appreciate it!

A ready-to-use Test Server implementation for your ASP.NET Core 3.1 project.

## Features included

- xUnit & Test-runnner for TDD (Test-Driven Development)
- Docker-Compose support for executing tests
- GitHub actions support (Docker)

## How to use
1) Copy/clone this project
2) Remove 'YourApi' folder and reference your real project
2) Modify/rename docker-compose.yml file as needed
3) Run it (cd `src/TestServer` && `dotnet test` or `docker-compose up`