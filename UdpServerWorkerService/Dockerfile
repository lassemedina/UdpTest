#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 1000/udp

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR "/src/UdpServerWorkerService"
#COPY ["UdpServerWorkerService/UdpServerWorkerService.csproj", "UdpServerWorkerService/"]
COPY . .
RUN dotnet restore "UdpServerWorkerService/UdpServerWorkerService.csproj"
RUN dotnet build "UdpServerWorkerService/UdpServerWorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UdpServerWorkerService/UdpServerWorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UdpServerWorkerService.dll"]