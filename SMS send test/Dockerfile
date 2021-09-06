FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SMS send test/SMS send test.csproj", "SMS send test/"]
RUN dotnet restore "SMS send test/SMS send test.csproj"
COPY . .
WORKDIR "/src/SMS send test"
RUN dotnet build "SMS send test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SMS send test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SMS send test.dll"]
