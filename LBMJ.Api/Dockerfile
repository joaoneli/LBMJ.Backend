#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LBMJ.Api/LBMJ.Api.csproj", "LBMJ.Api/"]
COPY ["LBMJ.IoC/LBMJ.IoC.csproj", "LBMJ.IoC/"]
COPY ["LBMJ.Dal/LBMJ.Dal.MySql.csproj", "LBMJ.Dal/"]
COPY ["LBMJ.Dal.Infra/LBMJ.Dal.Infra.csproj", "LBMJ.Dal.Infra/"]
COPY ["LBMJ.Models/LBMJ.Models.csproj", "LBMJ.Models/"]
COPY ["LBMJ.Bll/LBMJ.Bll.csproj", "LBMJ.Bll/"]
COPY ["LBMJ.Bll.Infra/LBMJ.Bll.Infra.csproj", "LBMJ.Bll.Infra/"]
COPY ["LBMJ.Token/LBMJ.Token.csproj", "LBMJ.Token/"]
RUN dotnet restore "LBMJ.Api/LBMJ.Api.csproj"
COPY . .
WORKDIR "/src/LBMJ.Api"
RUN dotnet build "LBMJ.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LBMJ.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LBMJ.Api.dll"]