FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DockerMVCTest/DockerMVCTest.csproj", "DockerMVCTest/"]
RUN dotnet restore "DockerMVCTest/DockerMVCTest.csproj"
COPY . .
WORKDIR "/src/DockerMVCTest"
RUN dotnet build "DockerMVCTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerMVCTest.csproj" -c Release -o /app/publish

FROM base AS runtime 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerMVCTest.dll"]