FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["./webapi/webapi.csproj", "webapi/"]
COPY ["./autenticacao/educae.identidade.app/educae.identidade.app.csproj", "educae.identidade.app/"]

COPY ["./biblioteca/educae.biblioteca.app/educae.biblioteca.app.csproj", "biblioteca/educae.biblioteca.app/"]
COPY ["./biblioteca/educae.biblioteca.domain/educae.biblioteca.domain.csproj", "biblioteca/educae.biblioteca.domain/"]
COPY ["./biblioteca/educae.biblioteca.infra/educae.biblioteca.infra.csproj", "biblioteca/educae.biblioteca.infra/"]

COPY ["./contas/educae.contas.app/educae.contas.app.csproj", "contas/educae.contas.app/"]
COPY ["./contas/educae.contas.domain/educae.contas.domain.csproj", "contas/educae.contas.domain/"]
COPY ["./contas/educae.contas.infra/educae.contas.infra.csproj", "contas/educae.contas.infra/"]

COPY ["./comunicacao/educae.comunicacao.app/educae.comunicacao.app.csproj", "comunicacao/educae.comunicacao.app/"]
COPY ["./comunicacao/educae.comunicacao.domain/educae.comunicacao.domain.csproj", "comunicacao/educae.comunicacao.domain/"]
COPY ["./comunicacao/educae.comunicacao.infra/educae.comunicacao.infra.csproj", "comunicacao/educae.comunicacao.infra/"]

RUN dotnet restore "webapi/webapi.csproj"
COPY . .
WORKDIR "webapi"
RUN dotnet build "webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]
