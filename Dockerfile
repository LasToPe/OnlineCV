FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["OnlineCV/OnlineCV.csproj", "OnlineCV/"]
RUN dotnet restore "OnlineCV/OnlineCV.csproj"
COPY . .
WORKDIR "/src/OnlineCV"
RUN dotnet build "OnlineCV.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OnlineCV.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OnlineCV.dll"]