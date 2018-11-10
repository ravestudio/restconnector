FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy and build everything else
COPY . ./
RUN dotnet publish -c Release -o /out

FROM microsoft/dotnet:runtime
WORKDIR /app
COPY --from=build-env /out .

ENTRYPOINT ["dotnet", "restconnector.dll"]
