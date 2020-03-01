FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Olimpia.Mongo.TransferMongo.Api/Olimpia.Mongo.TransferMongo.Api.csproj", "Olimpia.Mongo.TransferMongo.Api/"]
RUN dotnet restore "Olimpia.Mongo.TransferMongo.Api/Olimpia.Mongo.TransferMongo.Api.csproj"
COPY . .
WORKDIR "/src/Olimpia.Mongo.TransferMongo.Api"
RUN dotnet build "Olimpia.Mongo.TransferMongo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Olimpia.Mongo.TransferMongo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olimpia.Mongo.TransferMongo.Api.dll"]