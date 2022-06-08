#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ComunicadoSinistroDigital.csproj", "."]
RUN dotnet restore "./ComunicadoSinistroDigital.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ComunicadoSinistroDigital.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComunicadoSinistroDigital.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ComunicadoSinistroDigital.dll"]


# Get Base Image (Full .NET Core SDK)

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

#WORKDIR /app

# Copy csproj and restore

#COPY *.csproj ./

#RUN dotnet restore

# Copy everything else and build

#COPY . ./

#RUN dotnet publish -c Release -o out

# Generate runtime image

#FROM mcr.microsoft.com/dotnet/aspnet:5.0

#WORKDIR /app

#EXPOSE 80

#COPY --from=build-env /app/out .

#ENTRYPOINT ["dotnet", "ComunicadoSinistroDigital.dll"]