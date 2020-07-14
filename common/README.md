Generate C# from protos

protoc --proto_path=./ --csharp_out=./ForecastModels/ --csharp_opt=base_namespace=Forecast ./protos/WeatherForecast.proto


Pack Nuget Locally
`dotnet pack -o /path/to/local/packages/`

