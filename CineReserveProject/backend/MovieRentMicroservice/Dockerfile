FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_HTTP_PORTS=5000;5001
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MovieRentMicroservice.Presentation/MovieRentMicroservice.Presentation.csproj", "MovieRentMicroservice.Presentation/"]
COPY ["MovieRentMicroservice.Application/MovieRentMicroservice.Application.csproj", "MovieRentMicroservice.Application/"]
COPY ["MovieRentMicroservice.Domain/MovieRentMicroservice.Domain.csproj", "MovieRentMicroservice.Domain/"]
COPY ["MovieRentMicroservice.Infrastructure/MovieRentMicroservice.Infrastructure.csproj", "MovieRentMicroservice.Infrastructure/"]
RUN dotnet restore "MovieRentMicroservice.Presentation/MovieRentMicroservice.Presentation.csproj"
COPY . .
WORKDIR "/src/MovieRentMicroservice.Presentation"
RUN dotnet build "MovieRentMicroservice.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MovieRentMicroservice.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieRentMicroservice.Presentation.dll"]