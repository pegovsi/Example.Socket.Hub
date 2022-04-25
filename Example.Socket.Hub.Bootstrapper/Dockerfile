FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Example.Socket.Hub/Example.Socket.Hub.csproj", "Example.Socket.Hub/"]
RUN dotnet restore "Example.Socket.Hub/Example.Socket.Hub.csproj"
COPY . .
WORKDIR "/src/Example.Socket.Hub"
RUN dotnet build "Example.Socket.Hub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Example.Socket.Hub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.Socket.Hub.dll"]
