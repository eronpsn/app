#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app


FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /src
COPY ["Eclilar.WebApi/Eclilar.WebApi.csproj", "Eclilar.WebApi/"]
COPY ["Eclilar.InjecaoDependencia/Eclilar.InjecaoDependencia.csproj", "Eclilar.InjecaoDependencia/"]
COPY ["Eclilar.Aplicacao/Eclilar.Aplicacao.csproj", "Eclilar.Aplicacao/"]
COPY ["Eclilar.Dominio/Eclilar.Dominio.csproj", "Eclilar.Dominio/"]
COPY ["Eclilar.Dominio.Compartilhado/Eclilar.Dominio.Compartilhado.csproj", "Eclilar.Dominio.Compartilhado/"]
COPY ["Eclilar.Infraestrutura.BancoDados/Eclilar.Infraestrutura.BancoDados.csproj", "Eclilar.Infraestrutura.BancoDados/"]
COPY ["Eclilar.Infraestrutura.Seguranca/Eclilar.Infraestrutura.Seguranca.csproj", "Eclilar.Infraestrutura.Seguranca/"]
RUN dotnet restore "Eclilar.WebApi/Eclilar.WebApi.csproj"
COPY . .
WORKDIR "/src/Eclilar.WebApi"
RUN dotnet build "Eclilar.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Eclilar.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Eclilar.WebApi.dll"]
CMD ASPNETCORE_URLS ="http://*:$PORT" dotnet EclilarApi.dll
