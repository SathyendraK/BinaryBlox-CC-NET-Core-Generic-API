FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["{{cookiecutter.project_api_pkg}}/{{cookiecutter.project_api_pkg}}.csproj", "{{cookiecutter.project_api_pkg}}/"]
RUN dotnet restore "{{cookiecutter.project_api_pkg}}/{{cookiecutter.project_api_pkg}}.csproj"
COPY . .
WORKDIR "/src/{{cookiecutter.project_api_pkg}}"
RUN dotnet build "{{cookiecutter.project_api_pkg}}.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "{{cookiecutter.project_api_pkg}}.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# IMPORTANT: Swagger paths might not work if this is disabled.
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "{{cookiecutter.project_api_pkg}}.dll"]
