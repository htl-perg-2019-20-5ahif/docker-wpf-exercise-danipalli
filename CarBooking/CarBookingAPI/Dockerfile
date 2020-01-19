FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
COPY *.csproj .
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o build


FROM base AS runtime
WORKDIR /app
COPY --from=build /app/build ./
ENTRYPOINT ["dotnet", "CarBookingAPI.dll"]