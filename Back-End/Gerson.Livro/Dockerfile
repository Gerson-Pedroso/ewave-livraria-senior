FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Gerson.Livro/Gerson.Livro.csproj", "Gerson.Livro/"]
RUN dotnet restore "Gerson.Livro/Gerson.Livro.csproj"
COPY . .
WORKDIR "/src/Gerson.Livro"
RUN dotnet build "Gerson.Livro.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gerson.Livro.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN ls
ENTRYPOINT ["dotnet", "Gerson.Livro.dll"]
