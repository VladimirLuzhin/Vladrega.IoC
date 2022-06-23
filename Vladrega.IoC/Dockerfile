FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Vladrega.IoC/Vladrega.IoC.csproj", "Vladrega.IoC/"]
RUN dotnet restore "Vladrega.IoC/Vladrega.IoC.csproj"
COPY . .
WORKDIR "/src/Vladrega.IoC"
RUN dotnet build "Vladrega.IoC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Vladrega.IoC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vladrega.IoC.dll"]
