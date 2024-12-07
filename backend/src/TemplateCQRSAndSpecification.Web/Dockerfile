# См. статью по ссылке https://aka.ms/customizecontainer, чтобы узнать как настроить контейнер отладки и как Visual Studio использует этот Dockerfile для создания образов для ускорения отладки.

# Этот этап используется при запуске из VS в быстром режиме (по умолчанию для конфигурации отладки)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Этот этап используется для сборки проекта службы
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["backend/src/TemplateCQRSAndSpecification.Web/TemplateCQRSAndSpecification.Web.csproj", "backend/src/TemplateCQRSAndSpecification.Web/"]
COPY ["backend/src/TemplateModule/Template.Application/Template.Application.csproj", "backend/src/TemplateModule/Template.Application/"]
COPY ["backend/src/Shared/Template.Core/Template.Core.csproj", "backend/src/Shared/Template.Core/"]
COPY ["backend/src/Shared/Template.SharedKernel/Template.SharedKernel.csproj", "backend/src/Shared/Template.SharedKernel/"]
COPY ["backend/src/TemplateModule/Template.Domain/Template.Domain.csproj", "backend/src/TemplateModule/Template.Domain/"]
COPY ["backend/src/TemplateModule/Template.Infrastructure/Template.Infrastructure.csproj", "backend/src/TemplateModule/Template.Infrastructure/"]
RUN dotnet restore "./backend/src/TemplateCQRSAndSpecification.Web/TemplateCQRSAndSpecification.Web.csproj"
COPY . .
WORKDIR "/src/backend/src/TemplateCQRSAndSpecification.Web"
RUN dotnet build "./TemplateCQRSAndSpecification.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Этот этап используется для публикации проекта службы, который будет скопирован на последний этап
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TemplateCQRSAndSpecification.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Этот этап используется в рабочей среде или при запуске из VS в обычном режиме (по умолчанию, когда конфигурация отладки не используется)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TemplateCQRSAndSpecification.Web.dll"]