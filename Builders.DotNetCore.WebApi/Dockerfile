FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Builders.DotNetCore.WebApi/Builders.DotNetCore.WebApi.csproj", "Builders.DotNetCore.WebApi/"]
RUN dotnet restore "Builders.DotNetCore.WebApi/Builders.DotNetCore.WebApi.csproj"
COPY . .
WORKDIR "/src/Builders.DotNetCore.WebApi"
RUN dotnet build "Builders.DotNetCore.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Builders.DotNetCore.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Builders.DotNetCore.WebApi.dll"]