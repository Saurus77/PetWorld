# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopiujemy solution i projekty
COPY ./PetWorld.sln ./

COPY ./PetWorld.Web/PetWorld.Web.csproj ./PetWorld.Web/
COPY ./PetWorld.Application/PetWorld.Application.csproj ./PetWorld.Application/
COPY ./PetWorld.Domain/PetWorld.Domain.csproj ./PetWorld.Domain/
COPY ./PetWorld.Infrastructure/PetWorld.Infrastructure.csproj ./PetWorld.Infrastructure/

# Restore dependencies
RUN dotnet restore

# Kopiujemy resztę plików
COPY . .

# Publish Web app
RUN dotnet publish ./PetWorld.Web/PetWorld.Web.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV DOTNET_RUNNING_IN_CONTAINER=true
ENV DOTNET_URLS=http://+:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "PetWorld.Web.dll"]
