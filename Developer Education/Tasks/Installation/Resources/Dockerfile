#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.litium.cloud/runtime/litium:net6-latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Uncomment the line below to set database connection string as environment-variable:
# ENV Litium__Data__ConnectionString="Pooling=true;User Id=sa;Password=Pass@word;Database=LitiumEducation;Server=host.docker.internal,5434"

# In the task Configure SMTP it may be required to configure HTTPS port, if so uncomment this line:
# ENV ASPNETCORE_HTTPS_PORT="5001"

# If you have a license-key to Litium you can add it below to set it as an environment-variable:
# ENV Litium__License=""

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Litium.Accelerator.Mvc/Litium.Accelerator.Mvc.csproj", "Src/Litium.Accelerator.Mvc/"]
COPY ["Src/Litium.Accelerator.Elasticsearch/Litium.Accelerator.Elasticsearch.csproj", "Src/Litium.Accelerator.Elasticsearch/"]
COPY ["Src/Litium.Accelerator/Litium.Accelerator.csproj", "Src/Litium.Accelerator/"]
COPY ["Src/Litium.Accelerator.FieldTypes/Litium.Accelerator.FieldTypes.csproj", "Src/Litium.Accelerator.FieldTypes/"]
COPY ["Src/Litium.Accelerator.Administration.Extensions/Litium.Accelerator.Administration.Extensions.csproj", "Src/Litium.Accelerator.Administration.Extensions/"]
RUN dotnet restore "Src/Litium.Accelerator.Mvc/Litium.Accelerator.Mvc.csproj"
COPY . .
WORKDIR "/src/Src/Litium.Accelerator.Mvc"
RUN dotnet build "Litium.Accelerator.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Litium.Accelerator.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Litium.Accelerator.Mvc.dll"]