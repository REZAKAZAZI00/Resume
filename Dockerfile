#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Resume/Resume.Web.csproj", "Resume/"]
COPY ["Resume.Core/Resume.Core.csproj", "Resume.Core/"]
COPY ["Resume.DataLayer/Resume.DataLayer.csproj", "Resume.DataLayer/"]
RUN dotnet restore "./Resume/Resume.Web.csproj"
COPY . .
WORKDIR "/src/Resume"
RUN dotnet build "./Resume.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Resume.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Resume.Web.dll"]