#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

COPY ["dev_cert.pfx", "/https/dev_cert.pfx"]

COPY ["scalable-web-api/scalable-web-api.csproj", "scalable-web-api/"]
RUN dotnet restore "scalable-web-api/scalable-web-api.csproj"
COPY . .
WORKDIR "/src/scalable-web-api"
RUN dotnet build "scalable-web-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "scalable-web-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "scalable-web-api.dll"]