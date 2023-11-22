#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Deviot.Docs.App/Deviot.Docs.App.csproj", "Deviot.Docs.App/"]
RUN dotnet restore "Deviot.Docs.App/Deviot.Docs.App.csproj"
COPY . .
WORKDIR "/src/Deviot.Docs.App"
RUN dotnet build "Deviot.Docs.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Deviot.Docs.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Deviot.Docs.App.dll"]