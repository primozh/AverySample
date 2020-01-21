FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AverySample/AverySample.csproj", "AverySample/"]
RUN dotnet restore "AverySample/AverySample.csproj"
COPY . .
WORKDIR "/src/AverySample"
RUN dotnet build "AverySample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AverySample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AverySample.dll"]