FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["jectionpro-CLI.csproj", "./"]
RUN dotnet restore "jectionpro-CLI.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "jectionpro-CLI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "jectionpro-CLI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "jectionpro-CLI.dll"]
