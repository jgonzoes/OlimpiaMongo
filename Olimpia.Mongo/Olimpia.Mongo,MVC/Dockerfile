FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Olimpia.Mongo,MVC/Olimpia.Mongo,MVC.csproj", "Olimpia.Mongo,MVC/"]
RUN dotnet restore "Olimpia.Mongo,MVC/Olimpia.Mongo,MVC.csproj"
COPY . .
WORKDIR "/src/Olimpia.Mongo,MVC"
RUN dotnet build "Olimpia.Mongo,MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Olimpia.Mongo,MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Olimpia.Mongo,MVC.dll"]