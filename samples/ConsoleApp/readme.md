# Introduction

This is simple console app that uses the nuget libraries of this SDK.

# Run App Locally

1. Clone the repo
2. Nagivate to `/samples/ConsoleApp`
3. Open the `EdgeClient.ConsoleApp.csproj` using Visual Studio.
4. Update the following variables from `Program.cs` > `CreateAuthenticatedHttpClient`
     * edgeUrl - should end with `/edge/`
     * user
     * pass
5. Hit the run button.
6. You should be able to receive data from `graph API`, `history API`, and `alarms and events (ae) API`.

NOTE: If you have no Edge Rest API endpoint available, you may use our Mock Server from this [page](https://github.com/EmersonDeltaV/deltav-edge/blob/main/developer-guide/rest-api/rest-api.md#mock-server)