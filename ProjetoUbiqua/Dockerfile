#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjetoUbiqua/ProjetoUbiqua.csproj", "ProjetoUbiqua/"]
RUN dotnet restore "ProjetoUbiqua/ProjetoUbiqua.csproj"
COPY . .
WORKDIR "/src/ProjetoUbiqua"
RUN dotnet build "ProjetoUbiqua.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoUbiqua.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoUbiqua.dll"]