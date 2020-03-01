FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Olimpia.Mongo.Transfer.Api/Olimpia.Mongo.Transfer.Api.csproj", "Olimpia.Mongo.Transfer.Api/"]
RUN dotnet restore "Olimpia.Mongo.Transfer.Api/Olimpia.Mongo.Transfer.Api.csproj"
COPY . .
WORKDIR "/src/Olimpia.Mongo.Transfer.Api"
RUN dotnet build "Olimpia.Mongo.Transfer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Olimpia.Mongo.Transfer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olimpia.Mongo.Transfer.Api.dll"]