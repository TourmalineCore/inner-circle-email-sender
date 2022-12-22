#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EmailSender.Api/EmailSender.Api.csproj", "EmailSender.Api/"]
COPY ["EmailSender.Application/EmailSender.Application.csproj", "EmailSender.Application/"]
RUN dotnet restore "EmailSender.Api/EmailSender.Api.csproj"
COPY . .
WORKDIR "/src/EmailSender.Api"
RUN dotnet build "EmailSender.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmailSender.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailSender.Api.dll"]