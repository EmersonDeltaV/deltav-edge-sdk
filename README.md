# Edge Client SDK

## Table of Contents
- [Edge Client SDK](#edge-client-sdk)
  - [Table of Contents](#table-of-contents)
  - [About](#about)
  - [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
  - [Usage](#usage)
    - [Authentication](#authentication)
    - [Graph](#graph)
    - [History](#history)
    - [Alarm and Events](#alarm-and-events)
  - [Authors](#authors)

## About

This repository contains a C# Edge REST API Client SDK implemented via HttpClient to simplify Edge REST API consumption. The currently available Edge endpoints covered in this SDK are Authentication, Graph, History, and Alarm and Events.

## Getting Started

### Prerequisites

Before working with this SDK, please ensure that you have setup the following with your Edge installation:

```
1. A working and reachable Edge REST API endpoint
2. Authorized Credentials for your Edge REST API endpoint
```
For more information, please consult the Edge Environment User Guide.

## Usage

### Authentication
DeltaV.EdgeClient.Authentication

[![NuGet Version](https://img.shields.io/nuget/v/DeltaV.EdgeClient.Authentication)](https://www.nuget.org/packages/DeltaV.EdgeClient.Authentication) ![NuGet Downloads](https://img.shields.io/nuget/dt/DeltaV.EdgeClient.Authentication)


```
var handler = new HttpClientHandler();
var client = new HttpClient(handler);

var edgeUrl = "https://localhost/"; //add your Edge REST API IP here
var user = "user"; //add your REST API username here
var pass = "pass"; //add your REST API password here

client.BaseAddress = new Uri(edgeUrl);
var token = await edgeClient.RequestClientTokenAsync(new Emerson.EdgeClient.Authentication.Models.Credentials()
        {
            Username = user,
            Password = pass
        });

edgeClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);

```

### Graph
DeltaV.EdgeClient.Graph

[![NuGet Version](https://img.shields.io/nuget/v/DeltaV.EdgeClient.Graph)](https://www.nuget.org/packages/DeltaV.EdgeClient.Graph) ![NuGet Downloads](https://img.shields.io/nuget/dt/DeltaV.EdgeClient.Graph)

```
var client = GetAuthenticatedClient(); //see Authentication sample.

var entity = await client.GetGraphByEntityIdAsync(entityId, propertyList, relationshipList);
```

### History
Emerson.EdgeClient.History

[![NuGet Version](https://img.shields.io/nuget/v/DeltaV.EdgeClient.History)](https://www.nuget.org/packages/DeltaV.EdgeClient.History) ![NuGet Downloads](https://img.shields.io/nuget/dt/DeltaV.EdgeClient.History)

```
var client = GetAuthenticatedClient(); //see Authentication sample.

var history = await client.GetHistoryByIdAsync(entityId, field);
```

### Alarm and Events
Emerson.EdgeClient.AE

[![NuGet Version](https://img.shields.io/nuget/v/DeltaV.EdgeClient.AE)](https://www.nuget.org/packages/DeltaV.EdgeClient.AE) ![NuGet Downloads](https://img.shields.io/nuget/dt/DeltaV.EdgeClient.AE)

```
var client = GetAuthenticatedClient(); //see Authentication sample.

var history = await client.GetAeAsync(pageSize, pageNumber);
```

## Authors

- Lawrence Benitez
- Peter Balanag
- Gershon Young
- Carlo Tamayo

