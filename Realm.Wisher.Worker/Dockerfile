#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Realm.Wisher.Worker/Realm.Wisher.Worker.csproj", "Realm.Wisher.Worker/"]
RUN dotnet restore "Realm.Wisher.Worker/Realm.Wisher.Worker.csproj"
COPY . .
WORKDIR "/src/Realm.Wisher.Worker"
RUN dotnet build "Realm.Wisher.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Realm.Wisher.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Realm.Wisher.Worker.dll"]