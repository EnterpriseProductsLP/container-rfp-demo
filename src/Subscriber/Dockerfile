FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Subscriber/Subscriber.csproj Subscriber/
COPY Common/Common.csproj Common/
RUN dotnet restore Subscriber/Subscriber.csproj
COPY . .
WORKDIR /src/Subscriber
RUN dotnet build Subscriber.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Subscriber.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Subscriber.dll"]