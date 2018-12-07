FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY DFC.UMS.Microservice.sln ./
COPY DFC.UMS.Microservice/DFC.UMS.Microservice.csproj DFC.UMS.Microservice/
RUN dotnet restore DFC.UMS.Microservice/DFC.UMS.Microservice.csproj -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/DFC.UMS.Microservice
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DFC.UMS.Microservice.dll"]
