# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
RUN apt-get update && \
    apt-get install -y --no-install-recommends sqlite3 libsqlite3-dev && \
    rm -rf /var/lib/apt/lists/*
COPY --from=build /app/publish ./
RUN mkdir -p /app/Data && \
    chmod 777 /app/Data
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "PortfolioSite.dll"]