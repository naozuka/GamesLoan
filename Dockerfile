#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
# this script is for the api to wait to sql server container to response in the port
COPY ./wait-for-it.sh /wait-for-it.sh
RUN chmod +x wait-for-it.sh
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["GamesLoan.Api/GamesLoan.Api.csproj", "GamesLoan.Api/"]
COPY ["GamesLoan.Core/GamesLoan.Core.csproj", "GamesLoan.Core/"]
COPY ["GamesLoan.Infra/GamesLoan.Infra.csproj", "GamesLoan.Infra/"]
RUN dotnet restore "GamesLoan.Api/GamesLoan.Api.csproj"
COPY . .
WORKDIR "/src/GamesLoan.Api"
RUN dotnet build "GamesLoan.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamesLoan.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "GamesLoan.Api.dll"]
ENTRYPOINT ["/wait-for-it.sh", "db:1433", "-t", "120", "--", "dotnet", "GamesLoan.Api.dll"]