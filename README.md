# .NET Minimal API Tutorial Deploy on Blossom

A ready-to-deploy .NET Minimal API app to get you started quickly on [Blossom](https://blossom-cloud.com).

## Quick Start

```bash
# Install dependencies
dotnet restore

# Run the app
dotnet run
```

Visit `http://127.0.0.1:5000` in your browser to see the demo application.

<details>
<summary>Additional Information</summary>

### Environment Variables
- `PORT`: Change the port (default: 5000)
- `ASPNETCORE_ENVIRONMENT`: Set the environment (Development/Production)

### API Endpoints
```bash
# Get a greeting
curl http://127.0.0.1:5000/api/hello?name=John

# Echo a message
curl -X POST -H "Content-Type: application/json" \
     -d '{"message":"Hello"}' http://127.0.0.1:5000/api/echo
```
</details>
