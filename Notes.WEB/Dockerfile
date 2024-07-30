#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Notes.WEB/Notes.WEB.csproj", "Notes.WEB/"]
COPY ["Notes.Domain/Notes.Domain.csproj", "Notes.Domain/"]
COPY ["Notes.DB/Notes.DB.csproj", "Notes.DB/"]
RUN dotnet restore "./Notes.WEB/Notes.WEB.csproj"
COPY . .
WORKDIR "/src/Notes.WEB"
RUN dotnet build "./Notes.WEB.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notes.WEB.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notes.WEB.dll"]