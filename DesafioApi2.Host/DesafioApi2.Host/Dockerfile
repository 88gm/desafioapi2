#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DesafioApi2.Host/DesafioApi2.Host.csproj", "DesafioApi2.Host/"]
RUN dotnet restore "DesafioApi2.Host/DesafioApi2.Host.csproj"
COPY . .
WORKDIR "/src/DesafioApi2.Host"
RUN dotnet build "DesafioApi2.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioApi2.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioApi2.Host.dll"]