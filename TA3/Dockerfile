FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TA3.csproj", "TA3.csproj"]
RUN dotnet restore "TA3.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "TA3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TA3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TA3.dll"]
