FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Cmdlets/Cmdlets.csproj", "Cmdlets/"]
RUN dotnet restore "Cmdlets/Cmdlets.csproj"
COPY . .
WORKDIR "/src/Cmdlets"
RUN dotnet build "Cmdlets.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cmdlets.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cmdlets.dll"]
