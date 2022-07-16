FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8088

ENV ASPNETCORE_URLS=http://*:8088
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0  AS build
WORKDIR /src

COPY ["Empleado.WebApi/Empleado.WebApi.csproj", "Empleado.WebApi/"]
RUN dotnet restore "Empleado.WebApi/Empleado.WebApi.csproj"

COPY . .
WORKDIR "/src/Empleado.WebApi"
RUN dotnet build "Empleado.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Empleado.WebApi.csproj" -c Release -o /app/publish

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Empleado.WebApi.dll"]